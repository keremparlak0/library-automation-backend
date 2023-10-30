using Microsoft.EntityFrameworkCore;
namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
           IConfiguration configuration) => services.AddDbContext<DbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy(name: "MyAllowSpecificOrigins", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyHeader();
                });
            });
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        public static void IoC(this IServiceCollection services)
        {
           // services.AddScoped<IBookRepository, BookRepository>();
            //services.AddScoped<IBookService, BookManager>();
        }
        
            

    }
}
