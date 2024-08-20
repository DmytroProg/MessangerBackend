using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MessangerBackend.Filters;

public class LoggingFilter : Attribute, IActionFilter
{
    private readonly ILogger<LoggingFilter> _logger;
    private readonly string _methodName;

    /*public LoggingFilter(ILogger<LoggingFilter> logger)
    {
        _logger = logger;
    }*/

    public LoggingFilter([CallerMemberName] string? methodName = null)
    {
        _methodName = methodName;
    }

    // before action
    public void OnActionExecuting(ActionExecutingContext context)
    {
        //context.HttpContext.RequestServices.GetRequiredService<ILogger<LoggingFilter>>();
        Console.WriteLine($"Before action: [{_methodName}]");
    }

    // after action
    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($"After action: [{_methodName}]");
    }
}