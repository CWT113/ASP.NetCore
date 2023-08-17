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
    }
}
