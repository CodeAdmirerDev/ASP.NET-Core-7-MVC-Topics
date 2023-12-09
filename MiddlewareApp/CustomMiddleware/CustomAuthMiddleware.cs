using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MiddlewareApp.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomAuthMiddleware
    {


        private readonly RequestDelegate _next;

        public CustomAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer"))
            {
                string token = authHeader.Substring("Bearer ".Length).Trim();

                try
                {
                    // Validate the token
                    var claimsPrincipal = ValidateToken(token);
                    context.User = claimsPrincipal;
                }
                catch
                {
                    // Return unauthorized status code if the token is invalid
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    return;
                }
            }

            await _next(context);
        }

        private ClaimsPrincipal ValidateToken(string token)
        {
            // Implement validation logic here

        }
    }
}
