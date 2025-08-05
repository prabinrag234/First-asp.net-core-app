using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", (HttpContext context) => { 
//    context.Response.StatusCode = 201;
//    return "This is My first apt.net core project!"; });

app.Run(async (HttpContext context) => {
    
    string path = context.Request.Path;
    string method = context.Request.Method;

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
    else if (method== "GET" && path == "/product")
    {
        context.Response.StatusCode = 200;
        if(context.Request.Query.ContainsKey("id") && context.Request.Query.ContainsKey("name"))
        {
            string id = context.Request.Query["id"];
            string name = context.Request.Query["name"];
            await context.Response.WriteAsync("Yes you selected " + name + " with ID of " + id);
            return;
        }
        await context.Response.WriteAsync("kindly provide the product id and name");
    }
    else if (method == "POST" && path == "/product")
    {
        context.Response.StatusCode = 200;

        string id = "";
        string name = "";

        StreamReader reader = new StreamReader(context.Request.Body);
        string data = await reader.ReadToEndAsync();
        Dictionary <string, StringValues> dict = QueryHelpers.ParseQuery(data);

        if(dict != null)
        {
            if (dict.ContainsKey("id"))
            {
                id = dict["id"];
            }
            if (dict.ContainsKey("name"))
            {
                name = dict["name"];
            }
            await context.Response.WriteAsync("The " + id + " you passed with " + name);
            return;
        }
        
        await context.Response.WriteAsync("The content you send with body is "+ data);
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("Don't know where you are sorry");
    }
});

app.Run();