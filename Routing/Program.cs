var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoint =>
{
    endpoint.Map("/Home",async context =>
    {
        await context.Response.WriteAsync("Welcome to Home Page");
    });
    endpoint.MapGet("/About", async context =>
    {
        await context.Response.WriteAsync("Welcome to GET About Page");
    });
    endpoint.MapPost("/Contact", async context =>
    {
        await context.Response.WriteAsync("Welcome to POST Contact Page");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("No Match found");
});

app.Run();
