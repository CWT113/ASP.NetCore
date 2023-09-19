using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT封装.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("TestToken")]
        public ActionResult<string> TestToken()
        {
            //获取用户信息
            string Id = this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            string userName = this.User.FindFirst(ClaimTypes.Name)!.Value;
            return "ok" + Id + userName;
        }

        [HttpGet]
        [Route("Test2")]
        [AllowAnonymous]//忽略权限
        public ActionResult<string> Test2()
        {
            return "666";
        }

        [HttpGet]
        [Route("Test3")]
        [Authorize(Roles = "admin")]//admin管理员权限才可以访问
        public ActionResult<string> Test3()
        {
            return "8888";
        }
    }
}
