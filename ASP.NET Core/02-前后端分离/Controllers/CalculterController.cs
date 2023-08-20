using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _02_前后端分离.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculterController : ControllerBase
    {
        //依赖注入
        private readonly Calculate calculate;

        public CalculterController(Calculate calculate)
        {
            this.calculate = calculate;
        }

        [HttpPost]
        public int Add(int a, int b)
        {
            return calculate.Add(a, b);
        }
    }

    public class Calculate
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
