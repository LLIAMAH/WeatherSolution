namespace WeatherAPI.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request details
            _logger.LogInformation("Incoming request: {method} {url}", context.Request.Method, context.Request.Path);
            // Optionally, log the request body
            context.Request.EnableBuffering();
            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;
            _logger.LogInformation("Request body: {body}", requestBody);
            // Capture the response body
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;
            // Call the next middleware in the pipeline
            await _next(context);
            // Log the response details
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            _logger.LogInformation("Response: {statusCode} {body}", context.Response.StatusCode, responseBodyText);
            // Copy the response body back to the original stream
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
}
