using System.Reflection;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace UserMsrWebAPI.UnitOfWork
{
    /// <summary>
    /// 工作单元过滤器
    /// </summary>
    public class UnitOfWorkFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var result = await next();
            if (result.Exception != null) return;//说明存在异常
            var actionDesc = context.ActionDescriptor as ControllerActionDescriptor;
            if (actionDesc == null) return;
            var uowAttr = actionDesc.MethodInfo.GetCustomAttribute<UnitOfWorkAttribute>();
            if (uowAttr == null) return;

            foreach (Type dbCtxType in uowAttr.DbContextTypes)
            {
                //通过DI获取到每个DBContext实例
                var dbCtx = context.HttpContext.RequestServices.GetService(dbCtxType) as DbContext;
                if (dbCtx != null) await dbCtx.SaveChangesAsync();
            }
        }
    }
}
