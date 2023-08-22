using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Zack.ASPNETCore;

namespace _03_缓存.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        private readonly IMemoryCacheHelper memoryCacheHelper;

        public CacheController(IMemoryCache memoryCache, IMemoryCacheHelper memoryCacheHelper)
        {
            this.memoryCache = memoryCache;
            this.memoryCacheHelper = memoryCacheHelper;
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
                //绝对过期时间（10秒）
                //e.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);

                //滑动过期时间（在10秒内，再次从缓存中获取数据时，缓存有效期再加10秒【无限续命，再奶一口】）
                //e.SlidingExpiration = TimeSpan.FromSeconds(10);

                //缓存穿透：当我们查询一个数据库中不存在的数据时，请求会先去缓存中查看，没有缓存再去数据库获取，而数据库也没有数据。
                //        此时查询对于数据库的压力就会变得非常大，而这就会构成缓存穿透。
                //解决方案：当数据库查询不到数据时，返回值设置为null，存储到缓存中，下次请求直接返回null即可（缓存中允许存储null值）。
                Books? d = await MyDbContext.GetBookAsync(Id);
                Console.WriteLine("从数据库中查询的结果是" + (d == null ? "null" : d));
                return d;
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

        /// <summary>
        /// 借助封装的IMemoryCacheHelper类，实现IEnumerable的解耦和解决缓存雪崩的问题
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Books?>> Test1Async(long Id)
        {
            var res = await memoryCacheHelper.GetOrCreateAsync("Book" + Id, async (e) =>
            {
                return await MyDbContext.GetBookAsync(Id);
            }, 10);
            if (res == null)
            {
                return NotFound("不存在查询的书");
            }
            else
            {
                return res;
            }
        }
    }
}
