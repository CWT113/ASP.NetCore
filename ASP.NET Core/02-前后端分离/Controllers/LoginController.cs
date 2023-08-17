using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _02_前后端分离.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public LoginResponse Login(LoginRequest loginRequest)
        {
            if (loginRequest.Name == "admin" && loginRequest.Password == "1234")
            {
                //获取电脑当前的所有进程
                var process = Process.GetProcesses()
                    .Select(d => new ProcessInfo(d.Id, d.ProcessName, d.WorkingSet64));
                return new LoginResponse(true, process.ToArray());
            }
            else
            {
                return new LoginResponse(false, null);
            }
        }
    }

    /// <summary>
    /// 登录请求体
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Password"></param>
    public record LoginRequest(string Name, string Password);
    /// <summary>
    /// 登录响应体
    /// </summary>
    /// <param name="OK"></param>
    /// <param name="LoginInfos"></param>
    public record LoginResponse(bool OK, ProcessInfo[]? LoginInfos);
    /// <summary>
    /// 当前的线程信息
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Name"></param>
    /// <param name="WorkingSet"></param>
    public record ProcessInfo(long Id, string Name, long WorkingSet);
}
