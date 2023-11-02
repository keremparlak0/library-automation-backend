using API.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Entities;
using NLog;
using NLog.Web;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

var _logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
_logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);


    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
        b => b.MigrationsAssembly("API")));

    #region Cors
    builder.Services.AddCors(option =>
    {
        option.AddPolicy(name: "MyAllowSpecificOrigins", policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyHeader();
        });
    });
    #endregion

    #region IoC Registration
    builder.Services.AddScoped<IBookRepository, BookRepository>();
    builder.Services.AddScoped<IBookService, BookService>();
    builder.Services.AddSingleton<ILoggerService, LoggerService>();
    builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
    #endregion


    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


    #region Logging
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    #endregion

    #region Authentication
    builder.Services.AddAuthentication();
    builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 8;

        options.User.RequireUniqueEmail = true;
    })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/account/login";
        options.LogoutPath = "/account/logout";
        options.AccessDeniedPath = "/account/accessdenied";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(40);
    });
    #endregion
    var app = builder.Build();

    //Global Exception Handling
    var logger = app.Services.GetRequiredService<ILoggerService>();
    app.ConfigureExceptionHandler(logger);

    if (app.Environment.IsProduction())
    {
        app.UseHsts();
    }

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors("MyAllowSpecificOrigins");

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    _logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}