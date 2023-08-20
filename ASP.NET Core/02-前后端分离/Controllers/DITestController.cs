using ClassLibrary1;
using ClassLibrary2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _02_前后端分离.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DITestController : ControllerBase
    {
        //依赖注入
        private readonly Class1 class1;
        private readonly Class2 class2;
        private readonly Class3 class3;
        private readonly Class4 class4;

        public DITestController(Class1 class1, Class2 class2, Class3 class3, Class4 class4)
        {
            this.class1 = class1;
            this.class2 = class2;
            this.class3 = class3;
            this.class4 = class4;
        }

        [HttpGet]
        public string DITestString()
        {
            return class2.MyName() + class4.MyHello();
        }

        [HttpPost]
        public int DITestInt(int x, int y)
        {
            return class1.MyAdd(x, y) + class3.MyMutil(x, y);
        }
    }
}
