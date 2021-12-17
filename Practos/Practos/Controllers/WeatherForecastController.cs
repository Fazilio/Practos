using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Practos.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        public static IList<WeatherForecast> weatherForecasts = new List<WeatherForecast>
        {
            new WeatherForecast
            {
                Id = Guid.NewGuid(),
                Name = "GTX 1660",
                Date = DateTime.Now,
            }
        };


        /// <summary>
        /// Чтение всей записей
        /// </summary>

        [HttpGet]
        public IList<WeatherForecast> GetWeatherForecasts()
        {
            return weatherForecasts;
        }

        /// <summary>
        /// Ввод
        /// </summary>

        [HttpPost("{name}")]
        public IActionResult Post(string name)
        {
            if (ModelState.IsValid)
            {
                weatherForecasts.Add(new WeatherForecast
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Date = DateTime.Now,
                });
                return Ok(weatherForecasts);
            }
            return BadRequest(ModelState);
        }

        ///<summary>
        ///Чтение по ID
        ///</summary>

        [HttpGet("{id}")]
        public WeatherForecast Get(Guid id)
        {
            return weatherForecasts.FirstOrDefault(x => x.Id == id);
        }

        ///<summary>
        ///Удаление по ID
        ///</summary>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            WeatherForecast product = weatherForecasts.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                weatherForecasts.Remove(product);
            }
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, string name)
        {
            if (ModelState.IsValid)
            {
                var product = weatherForecasts.FirstOrDefault(x => x.Id == id);
                if (product != null)
                {
                    product.Name = name;
                }
                return Ok(product);
            }
            return BadRequest(ModelState);
        }
    }
}