using Covadis.API.Models;
using Covadis.Shared;
using Microsoft.AspNetCore.Mvc;

namespace corvadis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private static List<Car> Cars = new List<Car>
        {
            new Car {Name = "name", Model = "model"}
        };

        [HttpGet]
        public IActionResult Get()
        {
            var carDtos = Cars.Select(car => new CarDto
            {
                Name = car.Name,
                Model = car.Model
            });

            return Ok(carDtos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            Cars.Add(car);
            return Ok();
        }
    }
}
