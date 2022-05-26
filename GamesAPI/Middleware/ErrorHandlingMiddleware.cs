using GamesAPI.Exceptions;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace GamesAPI.Middleware
{
    internal sealed class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var error = DefineHttpError(ex);
            await WriteHttpResponseAsync(context, error);
        }

        private async Task WriteHttpResponseAsync(HttpContext context, HttpErrorModel error)
        {
            context.Response.StatusCode = (int)error.StatusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new { error.Details }), Encoding.UTF8);
        }

        private HttpErrorModel DefineHttpError(Exception exception)
        {
            return exception switch
            {
                NotFoundException nfex => new HttpErrorModel
                {
                    Details = new HttpErrorModel.ErrorDetails
                    { Text = nfex.Message },
                    StatusCode = HttpStatusCode.NotFound
                },
                _ => new HttpErrorModel
                {
                    Details = new HttpErrorModel.ErrorDetails
                    { Text = "Неопределенная ошибка сервера!" },
                    StatusCode = HttpStatusCode.InternalServerError
                },
            };
        }

        private class HttpErrorModel
        {
            public HttpStatusCode StatusCode;
            public ErrorDetails Details = new ErrorDetails();

            public class ErrorDetails
            {
                public string Text;
                public object Details;
            }
        }
    }
}
