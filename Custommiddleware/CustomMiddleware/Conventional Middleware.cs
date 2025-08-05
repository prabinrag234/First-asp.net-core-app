using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Custommiddleware.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Conventional_Middleware
    {
        private readonly RequestDelegate _next;

        public Conventional_Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Conventional Middleware executed.\n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("Conventional middleware execution completed.\n");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class Conventional_MiddlewareExtensions
    {
        public static IApplicationBuilder UseConventional_Middleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Conventional_Middleware>();
        }
    }
}
