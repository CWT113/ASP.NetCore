using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilter;

public class ActionFilters : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Console.WriteLine("AsyncActionFilter1:  之前执行！");
        ActionExecutedContext result = await next();
        if (result.Exception != null)
        {
            Console.WriteLine("AsyncActionFilter1： 发生异常");
        }
        else
        {
            Console.WriteLine("AsyncActionFilter1：  执行成功");
        }
    }
}
