using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01_ASP.NET_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public Person GetPerson()
        {
            return new Person("王一博", 18);
        }

        [HttpPost]
        public string[] SaveNoteRequest(SaveNoteRequest saveNote)
        {
            System.IO.File.WriteAllText(saveNote.Title + ".txt", saveNote.Content);
            return new string[] { "status: 200", "IsSuccess: success", saveNote.Title, saveNote.Content };
        }
    }
}
