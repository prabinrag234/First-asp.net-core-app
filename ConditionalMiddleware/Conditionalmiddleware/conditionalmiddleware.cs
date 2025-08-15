namespace ConditionalMiddleware.Conditionalmiddleware
{
    public class conditionalmiddleware: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Check if the request path starts with "/api"
            if (context.Request.Query.ContainsKey("IsAuthorized"))
            {
                await context.Response.WriteAsync("Executed Conditional Middleware.\n");
                // If it does, call the next middleware in the pipeline
                await next(context);
            }
            else
            {
                await context.Response.WriteAsync("Skipped Conditional Middleware.\n");
            }
        }
    }
}
