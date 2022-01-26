using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Excepitons;
using System.Text.Json;

namespace NLayer.API.MiddleWares
{
    public static class UseCustomExcepitonHandler
    {
        public static void UseCustomExcepiton(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var excepitonFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = excepitonFeature.Error switch
                    {
                        ClientSideException => 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response = CustomNoContentDto.Fail(statusCode, excepitonFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));


                });
            });
        }
    }
}
