using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentityController : ControllerBase
{
    private readonly UserManager<MyUser> userManager;
    private readonly RoleManager<MyRole> roleManager;

    public IdentityController(UserManager<MyUser> userManager, RoleManager<MyRole> roleManager)
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

    [HttpPost]
    [Route("GetUser")]
    public async Task<ActionResult> GetUser(CheckPassword check)
    {
        var userName = check.UserName;
        var password = check.Password;

        var user = await userManager.FindByNameAsync(userName);
        if (user == null)
        {
            return BadRequest("用户名不存在！");
        }

        //查看用户是否被锁定
        if (await userManager.IsLockedOutAsync(user))
        {
            return BadRequest($"用户已被锁定，锁定时间至{user.LockoutEnd}！");
        }

        if (await userManager.CheckPasswordAsync(user, password))
        {
            await userManager.ResetAccessFailedCountAsync(user);
            return Ok("登录成功！");
        }
        else
        {
            await userManager.AccessFailedAsync(user);
            return BadRequest("用户名或密码错误！");
        }
    }

    [HttpPost]
    [Route("SendResetPasswordToken")]
    public async Task<ActionResult> SendResetPasswordToken(string userName)
    {
        MyUser? user = await userManager.FindByNameAsync(userName);
        if (user == null) return BadRequest("用户不存在");
        string token = await userManager.GeneratePasswordResetTokenAsync(user);
        Console.WriteLine($"token是：" + token);
        return Ok();
    }

    [HttpPut]
    [Route("ResetPassword")]
    public async Task<ActionResult> ResetPassword(string userName, string token, string newPassword)
    {
        MyUser? user = await userManager.FindByNameAsync(userName);
        if (user == null) return BadRequest("用户不存在");
        IdentityResult? result =  await userManager.ResetPasswordAsync(user, token, newPassword);
        if (result.Succeeded)
        {
            await userManager.ResetAccessFailedCountAsync(user);
            return Ok("密码重置成功！");
        }
        else
        {
            await userManager.ResetAccessFailedCountAsync(user);
            return BadRequest("密码重置失败！");
        }
    }
}
