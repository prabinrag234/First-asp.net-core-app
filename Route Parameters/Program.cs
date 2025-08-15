var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/home/{auther?}/{id?}", async context =>
    {
        var id = Convert.ToInt32(context.Request.RouteValues["id"]);
        var auther = Convert.ToString(context.Request.RouteValues["auther"]);

        await context.Response.WriteAsync($"the auther is {auther} and ID is {id} ");
    });
});

app.Run( async (context) =>
{
    await context.Response.WriteAsync("Endpoint middleware done");
});

app.Run();
