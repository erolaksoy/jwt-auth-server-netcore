using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using WorkJwtExampleServer.SharedLibrary.DTOs;
using WorkJwtExampleServer.SharedLibrary.Exceptions;

namespace WorkJwtExampleServer.SharedLibrary.Extensions
{
    public static class CustomExceptionHandler
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var errorFeatures = context.Features.Get<IExceptionHandlerFeature>();

                    if (errorFeatures != null)
                    {
                        var ex = errorFeatures.Error;
                        CustomError errorDto = null;
                        if (ex is CustomException)
                        {
                            errorDto = new CustomError(ex.Message, true);
                        }
                        else
                        {
                            errorDto = new CustomError(ex.Message, false);
                        }

                        var response = Response<NoDataDto>.Fail(errorDto, 500);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }
}
