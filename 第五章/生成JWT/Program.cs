using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace 生成JWT;

public class Program
{
    static void Main(string[] args)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim(ClaimTypes.Name, "sunny"),
            new Claim(ClaimTypes.Role, "user"),
            new Claim(ClaimTypes.Role, "admin"),
            new Claim("passport", "E1234567"),
            new Claim("QQ", "779227561"),
        };

        //正确的密钥
        string key = "adasfafa@fafa*dafeaf232332#grgrgrgrgr";

        //错误的密钥
        //string key = "adasfafa@fafa*dafeaf232332#grgggggggggg";
        //过期时间
        DateTime expire = DateTime.Now.AddHours(1);

        byte[] secBytes = Encoding.UTF8.GetBytes(key);
        var secKey = new SymmetricSecurityKey(secBytes);
        var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(claims: claims, expires: expire, signingCredentials: credentials);
        string jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        Console.WriteLine(jwt);
    }
}