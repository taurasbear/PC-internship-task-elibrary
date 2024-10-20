namespace PCElibrary.Server.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using PCElibrary.Application.Common.Exceptions;

    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BadRequestException ex)
            {
                context.Result = new BadRequestObjectResult(new { message = ex.Message });
                context.ExceptionHandled = true;
            }
        }
    }
}
