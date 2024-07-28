using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace WpfApp1
{
    class GetAllDogs
    {
        private static readonly HttpClient client = new HttpClient();

        GetAllDogs()
        {
            client.BaseAddress = new Uri("https://dog.ceo/"); // Set the base API URL
        }

        
        public async Task<ActionResult<HttpResponseMessage>> GetTheDogs()
        {

            HttpResponseMessage response = await client.GetAsync("products"); // Relative URL
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                // Deserialize the response body
            }


            return Ok(response);
        }
    }
}
