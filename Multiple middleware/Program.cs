var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Middleware to handle requests and responses
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Executed first middleware");
    next(context);
});

// Second middleware to handle requests and responses
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Executed second middleware");
});

app.Run();
