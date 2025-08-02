var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", (HttpContext context) => { 
//    context.Response.StatusCode = 201;
//    return "This is My first apt.net core project!"; });

app.Run(async (HttpContext context) => {
    string path = context.Request.Path;
    if (path == "/" || path == "/home")
    {
        context.Response.StatusCode= 200;
        await context.Response.WriteAsync("You are in Home Page");
    }
    else if (path == "/context")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("You are in context");
    }
    else if (path == "/product")
    {
        context.Response.StatusCode = 200;
        if(context.Request.Query.ContainsKey("id") && context.Request.Query.ContainsKey("name"))
        {
            string id = context.Request.Query["id"];
            string name = context.Request.Query["name"];
            await context.Response.WriteAsync("Yes you selected" + name + "with ID of " + id);
        }
        await context.Response.WriteAsync("kindly provide the product id and name");
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("Don't know where you are sorry");
    }
});

app.Run();