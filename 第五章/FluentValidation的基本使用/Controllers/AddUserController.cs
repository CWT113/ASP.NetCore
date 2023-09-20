using Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation的基本使用.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUserController : ControllerBase
    {
        private readonly UserManager<MyUser> userManager;
        private readonly RoleManager<MyRole> roleManager;

        public AddUserController(UserManager<MyUser> userManager, RoleManager<MyRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<ActionResult<string>> AddRole()
        {
            if (await roleManager.RoleExistsAsync("admin") == false)
            {
                MyRole myRole = new MyRole { Name = "admin" };
                var result = await roleManager.CreateAsync(myRole);
                if (!result.Succeeded) return BadRequest("创建角色失败！");
            }

            MyUser? user = await userManager.FindByNameAsync("sunny");
            if (user == null)
            {
                user = new MyUser { UserName = "suuny" };
                var result = await userManager.CreateAsync(user);
                if (!result.Succeeded) return BadRequest("创建用户失败！");
            }

            if (!await userManager.IsInRoleAsync(user, "admin"))
            {
                var result = await userManager.AddToRoleAsync(user, "admin");
                if (!result.Succeeded) return BadRequest("绑定用户角色失败！");
            }

            return "OK";
        }
    }
}
