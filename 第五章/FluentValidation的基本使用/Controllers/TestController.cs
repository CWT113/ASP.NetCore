using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation的基本使用.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost]
        [Route("AddUser")]
        public ActionResult AddUser(AddNewUserRequest userInfo)
        {
            return Ok();
        }
    }
}
