using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace _03_缓存.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;

        public CacheController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<ActionResult<Books>> GetBookById(long Id)
        {
            Console.WriteLine($"开始查找数据");
            //GetOrCreateAsync做了两件事情：
            //1、从缓存中查数据，如果有，直接返回；
            //2、如果缓存中没有，则去数据库取数据，然后在缓存中存储数据；
            var res = await memoryCache.GetOrCreateAsync("Book" + Id, async (e) =>
            {
                Console.WriteLine($"缓存中没有，从数据库中去取");
                return await MyDbContext.GetBookAsync(Id);
            });
            Console.WriteLine($"GetOrCreateAsync的结果是{res}");
            if (res == null)
            {
                return NotFound($"找不到id={Id}的这本书");
            }
            else
            {
                return res;
            }
        }


        //cache-control缓存响应头，10表示缓存内容10秒
        [ResponseCache(Duration = 10)]
        [HttpGet]
        public DateTime GetNow()
        {
            return DateTime.Now;
        }
    }
}
