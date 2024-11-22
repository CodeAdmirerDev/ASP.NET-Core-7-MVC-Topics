using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareApp.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DummyMiddleware
    {
        private readonly RequestDelegate _next;

        public DummyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    //// Extension method used to add the middleware to the HTTP request pipeline.
    //public static class DummyMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseDummyMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<DummyMiddleware>();
    //    }
    //}
}
