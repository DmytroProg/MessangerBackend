using Microsoft.AspNetCore.Mvc.Filters;

namespace MessangerBackend.Filters;

public class ExceptionHandlerFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        Console.WriteLine($"ERROR: {context.ExceptionDispatchInfo?.SourceException.Message}");
        //context.HttpContext.Response.StatusCode = 401;
    }
}