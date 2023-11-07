using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models;
using NLog;
using NLog.Web;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var _logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
_logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);


    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        } );
        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
        b =>
        {
            b.MigrationsAssembly("API");
        }));

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
    #endregion

    #region AutoMapper
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    #endregion

    #region Logging
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    #endregion

    #region Auth-Jwt
    builder.Services.AddAuthentication().AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration
                    .GetSection("Authentication:Schemes:Bearer:SigningKeys:0:Value").Value))
            };
        });
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddScoped<IUserService, UserService>();
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

    //app.UseAuthentication(); //f8df94d5
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