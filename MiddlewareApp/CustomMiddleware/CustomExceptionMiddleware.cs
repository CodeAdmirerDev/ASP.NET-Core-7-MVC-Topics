using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace MiddlewareApp.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                int q = 0;

                int i = 1 / q;
                await _next(httpContext);

            }
            catch(Exception ex)
            {
                Console.WriteLine("In middleware exception occured"+ ex.Message.ToString());
                httpContext.Response.StatusCode= (int)HttpStatusCode.InternalServerError;
                await _next(httpContext);
            }

        }
    }

    //// Extension method used to add the middleware to the HTTP request pipeline.
    //public static class CustomExceptionMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<CustomExceptionMiddleware>();
    //    }
    //}
}
