using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilter;

public class ActionFilters2 : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Console.WriteLine("AsyncActionFilter2:  之前执行！");
        ActionExecutedContext result = await next();
        if (result.Exception != null)
        {
            Console.WriteLine("AsyncActionFilter2： 发生异常");
        }
        else
        {
            Console.WriteLine("AsyncActionFilter2：  执行成功");
        }
    }
}
