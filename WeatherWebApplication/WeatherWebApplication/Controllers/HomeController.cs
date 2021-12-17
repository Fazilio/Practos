using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using WeatherWebApplication.Models;

namespace WeatherWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHttpClientFactory httpClientFactory;

        public HomeController(ILogger<HomeController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(CancellationToken token)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://api.openweathermap.org/data/2.5/weather?q=Sankt-Peterburg&appid=a78ce7e78113bc3a04c9545ed216016f&units=metric", token);
            var payload = await response.Content.ReadAsStringAsync(token);

            var model = JsonConvert.DeserializeObject<OpenWeatherModel>(payload);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}