using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace FiltersInASPNETCoreMVCApp.Models
{
    public class CustomAsyncCacheActionFilter : IAsyncActionFilter
    {
        private readonly IMemoryCache _memoryCache;
        private readonly TimeSpan _expirationTimeSpan;

        public CustomAsyncCacheActionFilter(IMemoryCache memoryCache, double expireTimeInSeconds=30)
        {
            _memoryCache = memoryCache;
            _expirationTimeSpan = TimeSpan.FromSeconds(expireTimeInSeconds);
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Generate a cache key using path and query string to account for route and query parameters
            var cacheKey = $"{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString}";

            // Try to get the cached result from memory cache
            if (_memoryCache.TryGetValue(cacheKey, out IActionResult cachedResult))
            {
                // If cached, return the cached result
                context.Result = cachedResult;
            }
            else
            {
                // If not cached, proceed with the action execution
                var executedContext = await next();

                // If the result is a view or JSON response, cache it
                // You can adjust the condition based on the types of responses you'd like to cache
                if (executedContext.Result is ObjectResult objectResult)
                {
                    // Serialize and cache the actual data rather than the whole IActionResult
                    _memoryCache.Set(cacheKey, objectResult.Value, _expirationTimeSpan);
                }
                else
                {
                    // If it's a non-object result (like ViewResult, etc.), store it directly
                    _memoryCache.Set(cacheKey, executedContext.Result, _expirationTimeSpan);
                }
            }
        }
    }
}
