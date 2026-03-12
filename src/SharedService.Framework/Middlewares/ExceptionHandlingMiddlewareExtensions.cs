using Microsoft.AspNetCore.Builder;

namespace SharedService.Framework.Middlewares;

public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder) =>
        builder.UseMiddleware<ExceptionHandlingMiddleware>();
}