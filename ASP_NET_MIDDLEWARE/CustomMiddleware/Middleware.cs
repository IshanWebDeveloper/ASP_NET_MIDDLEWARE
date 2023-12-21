namespace ASP_NET_MIDDLEWARE.CustomMiddleware
{
    public class Middleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //Before logic
            await context.Response.WriteAsync("Custom Middleware started \n");
            await next(context);
            // after logic
            await context.Response.WriteAsync("Custom Middlware finished \n");
        }
    }
    //extension method
    /*Extension methods enable you to "add" methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type.*/
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder MyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Middleware>();
        }
    }
}
