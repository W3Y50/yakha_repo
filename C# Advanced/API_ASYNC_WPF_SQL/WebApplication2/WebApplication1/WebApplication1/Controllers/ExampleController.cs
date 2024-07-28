using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    public class ExampleController : Controller
    {
        [Route("/login")]
        public async Task<string> Login()
        {
            try
            {
               return (new TokenService()).GenerateToken(Guid.NewGuid().ToString(), "Admin");
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [Route("/SecureMethodWithRole")]
        [Authorize(Roles = "Admin")]
        public async Task<string> SecureMethodWithRole()
        {

            var userid = User.Claims.FirstOrDefault(c => c.Type == "testclaim")?.Value;

            return userid;
        }


        [Route("/SecureMethodWithoutRole")]
        [Authorize]
        public async Task<string> SecureMethodWithoutRole()
        {

            var userid = User.Claims.FirstOrDefault(c => c.Type == "testclaim")?.Value;

            return userid;
        }

    }
}
