
using CommentManagement.Api.Contracts.Results;
using CommentManagement.Entity.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CommentManagement.Api
{
    public class ExeptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExeptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException notfoundException)
            {
                context.Response.StatusCode = 604;
                await context
                    .Response
                    .WriteAsJsonAsync(new FailureResultDto(notfoundException.Message, 404));
            }
            catch (Exception e)
            {
                await context
                    .Response
                    .WriteAsJsonAsync(new FailureResultDto(e.Message,500));
            }
        }
    }
}
