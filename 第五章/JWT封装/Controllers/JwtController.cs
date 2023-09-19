using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JWT封装.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IOptionsSnapshot<JWTConfig> jwtOptions;

        public JwtController(IOptionsSnapshot<JWTConfig> jwtOptions)
        {
            this.jwtOptions = jwtOptions;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<string> Login(string userName, string password)
        {
            if (userName == "sunny" && password == "123456")
            {
                //添加用户信息
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, "1"),
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, "admin")
                };

                string key = jwtOptions.Value.Seckey;
                DateTime expire = DateTime.Now.AddSeconds(jwtOptions.Value.ExpireSeconds);

                byte[] secBytes = Encoding.UTF8.GetBytes(key);
                var secKey = new SymmetricSecurityKey(secBytes);
                var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
                var tokenDescriptor = new JwtSecurityToken(claims: claims, expires: expire, signingCredentials: credentials);
                string jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

                return jwt;
            }
            else
            {
                return BadRequest("用户名或密码错误!");
            }
        }
    }
}
