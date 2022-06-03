using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MovieStore.Api.Middlewares;

public static class UseCustomExeption
{
    public static void UseCustomExeptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(config =>
        {
            config.Run( async context =>
            {
                context.Response.ContentType = "application/json";
                var exeptionFeatures = context.Features.Get<IExceptionHandlerFeature>();
                var statusCode = exeptionFeatures.Error switch
                {
                    _=> 500

                };
                context.Response.StatusCode = statusCode;
                var response= new ObjectResult(exeptionFeatures.Error.Message);

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            });
        });
    }
}
