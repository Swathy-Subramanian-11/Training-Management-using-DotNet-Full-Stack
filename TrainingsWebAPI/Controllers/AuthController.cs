using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TrainingsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private string GenerateJWT(string username, string role, string secretKey)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            Claim[] claims = new Claim[]
            {
                new Claim (ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role,role)
            };
            var token = new JwtSecurityToken(
             issuer: "https://www.Chetan.com",
             audience: "https://www.Chetan.com",
             expires: DateTime.Now.AddHours(1),
             signingCredentials: credentials,
             claims: claims
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet("Token/{username}/{role}/{secretKey}")]
        public ActionResult GetToken(string username, string role, string secretKey)
        {
            string token = GenerateJWT(username, role, secretKey);
            return Ok(token);
        }
    }
}
