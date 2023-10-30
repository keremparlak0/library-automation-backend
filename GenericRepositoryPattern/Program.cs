using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi.Repositories;
using WebApi.Repositories.Contracts;
using AutoMapper.Configuration;
using WebApi.Extensions;
using Microsoft.Extensions.Configuration;
using WebApi.Services.Contracts;
using WebApi.Services;
using Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
    b => b.MigrationsAssembly("WebApi")));

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

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();


builder.Services.ConfigureAutoMapper();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyAllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();