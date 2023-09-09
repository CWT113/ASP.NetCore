using System.Reflection;
using System.Transactions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilter;

public class TransactionScopeFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //context.ActionDescriptor：是当前被执行的Action方法的描述信息
        //context.ActionArguments：是当前被执行的Action方法的参数信息
        ControllerActionDescriptor? ctrlActionDesc = context.ActionDescriptor as ControllerActionDescriptor;
        //是否进行事务控制
        bool isTx = false;
        if (ctrlActionDesc != null)
        {
            //查看方法上是否标注 NotTransactionAttribute 这个 Attribute
            bool hasNotTransactionAttribute = ctrlActionDesc.MethodInfo
                .GetCustomAttributes(typeof(NotTransactionAttribute), false).Any();
            isTx = !hasNotTransactionAttribute;
        }
        if (isTx)
        {
            using TransactionScope tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var r = await next();
            if (r.Exception == null) tx.Complete();
        }
        else
        {
            await next();
        }
    }
}
