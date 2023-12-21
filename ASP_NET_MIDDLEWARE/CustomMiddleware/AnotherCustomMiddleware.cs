namespace ASP_NET_MIDDLEWARE.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AnotherCustomMiddleware
    {
        private readonly RequestDelegate _next;
        //requestDelegate type will be injected by the framework
        public AnotherCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Another Custom Middleware called\n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("Another Custom Middleware finished\n");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AnotherCustomMiddlewareExtensions
    {
        //Use is a convention to denote that this is a middleware
        public static IApplicationBuilder UseAnotherCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AnotherCustomMiddleware>();
        }
    }
}
