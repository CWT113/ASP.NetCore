using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filter.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DemoController : ControllerBase
{
    [HttpGet]
    public string GetFile() => System.IO.File.ReadAllText("E:/1.txt");
}
