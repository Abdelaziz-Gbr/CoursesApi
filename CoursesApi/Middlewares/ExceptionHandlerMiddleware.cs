using System.Net;

namespace CoursesApi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate requestDelegate;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate requestDelegate)
        {
            this.logger = logger;
            this.requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                // log the error
                var error_id = Guid.NewGuid();
                logger.LogError(ex, $"[{error_id}]: {ex.Message}");

                // send a proper response to the client
                httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";
                var error = new
                {
                    Id = error_id,
                    Message = $"error id: {error_id} - please contact support, or try again."
                };
                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
