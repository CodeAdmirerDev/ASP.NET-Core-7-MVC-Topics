using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersInASPNETCoreMVCApp.Models
{
    public class CustomResultFilterApproachThree : Attribute, IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            // Check if the response should be compressed
            if (ShouldCompressResponse(context.HttpContext))
            {
                // Create a memory stream to store the response
                var originalResponse = context.HttpContext.Response.Body;
                using (var compressedStream = new MemoryStream())
                {
                    // Set the response to a compressed stream
                    context.HttpContext.Response.Body = compressedStream;

                    // Proceed with the rest of the pipeline
                    await next();

                    // Reset the position of the stream before reading it
                    compressedStream.Seek(0, SeekOrigin.Begin);

                    // Compress the stream (gzip in this case)
                    using (var gzipStream = new System.IO.Compression.GZipStream(originalResponse, System.IO.Compression.CompressionLevel.Fastest, true))
                    {
                        await compressedStream.CopyToAsync(gzipStream);
                    }
                }
            }
            else
            {
                // Proceed without compression if the condition is not met
                await next();
            }
        }

        // Check whether the response should be compressed
        private bool ShouldCompressResponse(HttpContext context)
        {
            // Check if the client supports compression (Accept-Encoding header)
            var acceptEncoding = context.Request.Headers["Accept-Encoding"].ToString();
            return acceptEncoding.Contains("gzip", System.StringComparison.OrdinalIgnoreCase) ||
                   acceptEncoding.Contains("deflate", System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
