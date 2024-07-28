using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text; 

namespace WebApplication1
{
    public class TokenService
    {
        public string GenerateToken(string userid, string userrole)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("testtesttesttesttesttesttesttest");
            SecurityTokenDescriptor? tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new  ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, userid),
            new Claim(ClaimTypes.Role, userrole), 
            new Claim("testclaim","claim1")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "organization", 
                Audience = "audience"
            };

            SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);
         
            return tokenHandler.WriteToken(token);
        }
    }
}
