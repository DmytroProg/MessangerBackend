using Microsoft.AspNetCore.Mvc.Filters;

namespace MessangerBackend.Filters;

public class AuthFilter : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var tokenCount = context.HttpContext.Request.Headers.Authorization.Count;
        Console.WriteLine($"Before: [{tokenCount}]");
        if (tokenCount == 0)
        {
            context.HttpContext.Abort();
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        
    }
}