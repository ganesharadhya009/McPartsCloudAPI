using Microsoft.AspNetCore.Diagnostics;

namespace McPartsAPI.Common.Middlewares
{
    public class GlobalApiExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalApiExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IExceptionHandler customExceptionHandler)
        {
            try
            {
                await _next(httpContext);

                switch (httpContext.Response.StatusCode)
                {
                    case StatusCodes.Status401Unauthorized:
                        await customExceptionHandler.TryHandleAsync(
                            httpContext,
                            new UnauthorizedAccessException("Unauthorized - Token missing or invalid"),
                            CancellationToken.None
                        );
                        break;

                    case StatusCodes.Status403Forbidden:
                        await customExceptionHandler.TryHandleAsync(
                            httpContext,
                            new Exception("Forbidden - Access denied"),
                            CancellationToken.None
                        );
                        break;

                    default:
                        // Let other status codes pass through
                        break;
                }
            }
            catch (Exception ex)
            {
                await customExceptionHandler.TryHandleAsync(httpContext, ex, CancellationToken.None);
            }
        }
    }

    //public class ApiKeyMiddleware
    //{
    //    private const string API_KEY_HEADER_NAME = "X-Api-Key";
    //    private readonly RequestDelegate _next;
    //    private readonly string _validApiKey;

    //    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    //    {
    //        _next = next;
    //        _validApiKey = configuration["TenantInfo:APIKey"];
    //    }

    //    public async Task InvokeAsync(HttpContext context)
    //    {
    //        if (!context.Request.Headers.TryGetValue(API_KEY_HEADER_NAME, out var receivedApiKey) || receivedApiKey != _validApiKey)
    //        {
    //            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
    //            await context.Response.WriteAsync("Invalid or missing API Key.");
    //            return;
    //        }

    //        await _next(context);
    //    }
    //}
}
