using ConditionalMiddleware.Conditionalmiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<conditionalmiddleware>();
var app = builder.Build();

// Middleware 1.
app.Use(async (HttpContext context, RequestDelegate req) =>
{
    await context.Response.WriteAsync("Executed Middleware 1.\n");
    // Call the next middleware in the pipeline.
    await req(context);
});

app.UseMiddleware<conditionalmiddleware>();

// Middleware 2.
app.UseWhen(context => context.Request.Query.ContainsKey("IsAuthorized") && context.Request.Query["IsAuthorized"] == "true",
    app =>
    {
        app.Use(async (HttpContext context, RequestDelegate req) =>
        {
            await context.Response.WriteAsync("Executed Middleware 2.");
        });
    });

app.Run();
