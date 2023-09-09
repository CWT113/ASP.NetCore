using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter;

public class ExceptionFilter : IAsyncExceptionFilter
{
    private readonly IWebHostEnvironment webHostEnvironment;

    public ExceptionFilter(IWebHostEnvironment webHostEnvironment)
    {
        this.webHostEnvironment = webHostEnvironment;
    }

    public Task OnExceptionAsync(ExceptionContext context)
    {
        string msg;
        if (webHostEnvironment.IsDevelopment())
        {
            msg = context.Exception.Message.ToString();
        }
        else
        {
            msg = "服务器端发生未处理异常";
        }

        ObjectResult objectResult = new ObjectResult(new { code = "500", message = msg });
        context.Result = objectResult;
        //后续过滤器均不在执行
        context.ExceptionHandled = true;

        return Task.CompletedTask;
    }
}
