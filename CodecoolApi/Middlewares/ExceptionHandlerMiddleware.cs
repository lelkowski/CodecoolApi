using CodecoolApi.Services.Exceptions;
using System.Net;

namespace CodecoolApi.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
            => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try { await next.Invoke(context); }
            catch (ResourceNotFoundException resourceNotFoundException)
            {
                _logger.LogInformation($"({DateTime.Now}) ResourceNotFoundException: {context.Request.Method}: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}\n\t{resourceNotFoundException.Message}");
                await HandleExceptionAsync(context, resourceNotFoundException, HttpStatusCode.NotFound).ConfigureAwait(false);
            }
            catch (InvalidCredentialsException invalidCretendialsException)
            {
                _logger.LogInformation($"({DateTime.Now}) InvalidCredentialsException: {context.Request.Method}: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}\n\t{invalidCretendialsException.Message}");
                await HandleExceptionAsync(context, invalidCretendialsException, HttpStatusCode.Forbidden).ConfigureAwait(false);
            }
            catch (ResourceAlreadyExistsException resourceAlreadyExistsException)
            {
                _logger.LogInformation($"({DateTime.Now}) ResourceAlreadyExistsException: {context.Request.Method}: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}\n\t{resourceAlreadyExistsException.Message}");
                await HandleExceptionAsync(context, resourceAlreadyExistsException, HttpStatusCode.Conflict).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                _logger.LogError($"({DateTime.Now}) Unhandled Exception: {context.Request.Method}: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}\n\n{exception.Message}\n{exception}");
                await HandleExceptionAsync(context, exception, HttpStatusCode.InternalServerError).ConfigureAwait(false);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsJsonAsync(new { Error = exception.Message });
        }
    }
}
