using Custommiddleware.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<CustomeMiddleware>();

var app = builder.Build();

app.Use( async(HttpContext context, RequestDelegate next) =>
{
    // Log middleware execution
    await context.Response.WriteAsync("Successfuly Lunched the First Middleware\n");

    // Log the request path
    await next(context);
});

app.UseMiddleware<CustomeMiddleware>();

app.Use((HttpContext context, RequestDelegate next) =>
{
    // Log middleware execution
    return context.Response.WriteAsync("Successfuly Lunched the Second Middleware\n");
});

app.Run();
