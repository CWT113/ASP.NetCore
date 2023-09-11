using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace ActionFilter;

public class RateLimitFilter : IAsyncActionFilter
{
    public readonly IMemoryCache memoryCache;

    public RateLimitFilter(IMemoryCache memoryCache)
    {
        this.memoryCache = memoryCache;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //获取当前用户的IP地址
        string IP = context.HttpContext.Connection.RemoteIpAddress!.ToString();
        string cacheKey = $"lastVisitKey_{IP}";
        long? lastVisit = memoryCache.Get<long?>(cacheKey);

        if (lastVisit == null || Environment.TickCount64 - lastVisit > 1000)
        {
            memoryCache.Set(cacheKey, Environment.TickCount64, TimeSpan.FromSeconds(10));
            await next();
        }
        else
        {
            ObjectResult result = new ObjectResult("访问太频繁") { StatusCode = 429 };
            context.Result = result;
        }
    }
}
