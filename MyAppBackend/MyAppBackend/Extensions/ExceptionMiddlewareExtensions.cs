using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using MyAppBackend.Models;
using System.Net;

namespace MyAppBackend.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {                   
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var body = context.Response.Body;
                    if (contextFeature != null)
                    {                     
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Error = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
