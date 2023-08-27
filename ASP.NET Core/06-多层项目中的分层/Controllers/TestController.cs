using EFCoreBook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _06_多层项目中的分层.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //依赖注入
        private readonly MyDBContext _myDBContext;

        public TestController(MyDBContext myDBContext)
        {
            this._myDBContext = myDBContext;
        }

        [HttpGet]
        public string Test1()
        {
            int count = this._myDBContext.Books.Count();
            return $"书的数量为{count}";
        }
    }
}
