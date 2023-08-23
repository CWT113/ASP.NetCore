using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _04_环境变量.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnvController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public EnvController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public string? GetEnvironment()
        {
            //返回系统的环境变量
            //return Environment.GetEnvironmentVariable("COUNT");

            //返回开发环境/生产环境配置的环境变量
            return webHostEnvironment.EnvironmentName;
        }
    }
}
