// Create an instance of web application builder
using ASP_NET_MIDDLEWARE.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<Middleware>();

// create an instance of web application
var app = builder.Build();

/*Middleware 1*/
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware in ASP \n");
    await next(context);
});

// Middelware 2
//types for parameters are inherited from previous middleware
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Middleware2 in ASP \n\n");
    await next(context);
});
//Middleware 3 - using custom middleware class
//app.UseMiddleware<Middleware>();
app.MyMiddleware();
app.UseAnotherCustomMiddleware();
//Middleware 4 conditional middleware
app.UseWhen((context) => context.Request.Query.ContainsKey("isAuthorized") && context.Request.Query["isAuthorized"] == "true", app => app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Middleware  4 called");
    await next(context);
}));
//if Middleware 5; doesn't have to run another middleware on the request pipeline, use run() method to call the final middleware on the request pipline
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Middleware 5 called\n\n");
});

app.Run();
