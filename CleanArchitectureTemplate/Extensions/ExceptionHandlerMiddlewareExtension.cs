﻿namespace BackendWashMe.Extensions
{
    using BackendWashMe.Middlewares;
    using Microsoft.AspNetCore.Builder;

    public static class ExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
