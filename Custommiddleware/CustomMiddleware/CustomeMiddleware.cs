
namespace Custommiddleware.CustomMiddleware
{
    public class CustomeMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custome Middleware executed.\n");
            await next(context);
            await context.Response.WriteAsync("Custome middleware execution completed \n");
        }
    }

}
