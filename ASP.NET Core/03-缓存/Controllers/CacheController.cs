using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _03_缓存.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        //cache-control缓存响应头，10表示缓存内容10秒
        [ResponseCache(Duration = 10)]
        [HttpGet]
        public DateTime GetNow()
        {
            return DateTime.Now;
        }
    }
}
