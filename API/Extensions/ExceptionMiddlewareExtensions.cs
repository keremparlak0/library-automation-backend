using Microsoft.AspNetCore.Diagnostics;
using Models.ErrorModel;
using Services;
using Services.Contracts;
using System.Net;

namespace API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextfeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextfeature != null)
                    {
                        logger.LogError("There is a problem: " + contextfeature.Error);

                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error"
                        }.ToString());
                    }
                });
            });
        }
    }
}
