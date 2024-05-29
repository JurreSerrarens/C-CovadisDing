using corvadis.API.Context;
using corvadis.API.models;
using Covadis.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace corvadis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private CovadisDbContext context;
        public CarController(CovadisDbContext context) 
        {
            this.context = context;
        }
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

        [HttpPut]
        public IActionResult Update([FromBody] Car car)
        { 
            Car oldCar = context.Cars.SingleOrDefault(x => x.Id == car.Id);
            oldCar.Name = car.Name;
            oldCar.Model = car.Model;
            //oudeBoek.AantalBladzijden = boek.AantalBladzijden;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {

            context.Cars.Where(x => x.Id == Id).ExecuteDelete();
            context.SaveChanges();
            return Ok();
        }
    }
}
