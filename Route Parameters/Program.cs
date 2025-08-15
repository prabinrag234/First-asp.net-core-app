var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/home/{anothertext}/{id}", async context =>
    {
        var id = Convert.ToInt32(context.Request.RouteValues["id"]);
        var anotherText = Convert.ToString(context.Request.RouteValues["anothertext"]);
        await context.Response.WriteAsync($"Hello, World! {id} and {anotherText}");
    });
});

app.Run( async (context) =>
{
    await context.Response.WriteAsync("Endpoint middleware done");
});

app.Run();
