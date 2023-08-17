using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01_ASP.NET_Core.Controllers
{
    //RPC风格
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpGet]
        public Person[] GetAll()
        {
            return new Person[]
            {
                new Person(1, "王一博", 18),
                new Person(2,"sunny", 22),
                new Person(3,"tom", 20)
            };
        }

        [HttpGet]
        public Person? GetById(long Id)
        {
            switch (Id)
            {
                case 1:
                    return new Person(1, "王一博", 18);
                case 2:
                    return new Person(2, "sunny", 22);
                case 3:
                    return new Person(3, "tom", 20);
                default:
                    return null;
            }
        }

        [HttpPost]
        public Person AddPerson(Person person)
        {
            return person;
        }

        //异步方法
        [HttpGet]
        public async Task<string> ReadTxt()
        {
            string text = await System.IO.File.ReadAllTextAsync(@"E:\projects\ASP.NET Core\test.txt");
            return text;
        }

        //IActionResult
        [HttpGet]
        public IActionResult GetSorce(int Id)
        {
            switch (Id)
            {
                case 1:
                    return Ok(99);
                case 2:
                    return Ok(66);
                default:
                    return NotFound("请输入正确的Id字段!");
            }
        }

        //泛型的ActionResult
        [HttpGet]
        public ActionResult<int> GetSorce1(long Id)
        {
            switch (Id)
            {
                case 1:
                    return 100;
                case 2:
                    return 66;
                default:
                    return NotFound("请输入正确的Id字段!");
            }
        }

        //捕捉URL占位符（参数名称原则上和url占位符相同）
        [HttpGet("student/{school}/class/{id}")]
        public dynamic GetStudent(string school, int id)
        {
            return new { id, school };
        }

        //捕捉URL占位符（参数名称不和url占位符相同，使用FromRoute解决）
        [HttpGet("student/{school}/class/{id}")]
        public dynamic GetStudent1(string school, [FromRoute(Name = "id")] int MyID)
        {
            return new { MyID, school };
        }
    }
}
