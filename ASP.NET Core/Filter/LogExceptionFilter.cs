using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter;

public class LogExceptionFilter : IAsyncExceptionFilter
{
    public Task OnExceptionAsync(ExceptionContext context) 
        => File.AppendAllTextAsync("E:/log.txt", context.Exception.ToString());
}
