using AcunMedyaMenu.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AcunMedyaMenu.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://the-weather-api.p.rapidapi.com/api/weather/ankara"),
                Headers =
    {
        { "x-rapidapi-key", "630ce9cc86msh271c60cffe62d5ep1b514djsn0fe292593744" },
        { "x-rapidapi-host", "the-weather-api.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherViewModel>(body);
                return View(values.data);
            }
            
        }
    }
}
