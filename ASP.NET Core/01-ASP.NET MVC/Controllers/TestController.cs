using _01_ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_ASP.NET_MVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Demo()//Action方法
        {
            Person person = new Person("王一博", true,DateTime.Now);
            return View(person);
        }
    }
}
