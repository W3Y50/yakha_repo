using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

 
    public class ExampleController : Controller
    {
        [Route("/testroute1")]
        public async Task<string> TestRoute1()
        {
            return "First value";
        }

        [Route("/testroute2")]
        [HttpGet]
        public async Task<double> TestRoute1(double a, double b)
        {
            return a + b;
        }

        [Route("api/testroute3")]
        [HttpPost]
        public async Task<double> TestRoute3([FromBody]ExamplePostModel requestdata)
        {
            return requestdata.a + requestdata.b;
        }

        [Route("api/testroute4")]
        [HttpPost]
        public async Task<ExampleCalculations> TestRoute4([FromBody] ExamplePostModel requestdata)
        {
            ExampleCalculations calculations = new ExampleCalculations();
            calculations.Calculation1 = requestdata.a + requestdata.b;
            calculations.Calculation2 = requestdata.a * requestdata.b;

            return calculations;
        }

        [Route("/testroute5")]
        [HttpGet("CalculateCircumference")]
        public async Task<double> CalculateCircumference(double radius)
        {
            // Calculate the circumference
            return 2 * Math.PI * radius;
        }

        [Route("/testroute6")]
        [HttpGet("CalculateVolumeOfCone")]
        public async Task<double> CalculateVolumeOfCone(double radius, double height)
        {
            // Calculate the Volume of a cone
            return (1.0 / 3.0) * Math.PI * Math.Pow(radius, 2) * height;
        }

        [Route("/testroute7")]
        [HttpGet("CalculateAreaOfTrapezoid")]
        public async Task<double> CalculateAreaOfTrapezoid(double base1, double base2, double height)
        {
            // Calculate the area
            return 0.5 * (base1 + base2) * height;
        }

    }
}
