using Norator.Middleware;

namespace Norator.Middleware
{
    public static class ApplicationMiddlewareConfiguration
    {
        public static void AddApplicationMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
