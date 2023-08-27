using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace _05_综合配置集成1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOptions<StmpSetting> options;
        private readonly IConnectionMultiplexer connectionMultiplexer;

        public ValuesController(IOptions<StmpSetting> options, IConnectionMultiplexer connectionMultiplexer)
        {
            this.options = options;
            this.connectionMultiplexer = connectionMultiplexer;
        }

        [HttpGet]
        public string GetValue()
        {
            return options.Value.ToString() + "   " + connectionMultiplexer.GetDatabase(0).Ping();
        }
    }
}
