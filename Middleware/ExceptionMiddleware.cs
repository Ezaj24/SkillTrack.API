using System.Net;
using System.Text.Json;

namespace SkillTrack.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);  // Continue pipeline
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message); // Log internally

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = ex.Message.Contains("not found", StringComparison.OrdinalIgnoreCase)
                ? (int)HttpStatusCode.NotFound
                : (int)HttpStatusCode.BadRequest;

            var response = new
            {
                status = statusCode,
                message = ex.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
