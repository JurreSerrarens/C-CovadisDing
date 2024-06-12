using Covadis.API.Models;
using Covadis.Shared;
using Covadis.API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Covadis.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private CovadisDbContext context;
        public CarController(CovadisDbContext context) 
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var carDtos = context.Cars.Select(car => new CarDto
            {
                Name = car.Name,
                Model = car.Model
            });

            return Ok(carDtos);
        }
        [HttpGet("getCar/{id}")]
        public IActionResult GetById(int id)
        {
            var carDto = context.Cars.FirstOrDefault(x => x.Id == id);
            return Ok(carDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Car car)
        { 
            Car oldCar = context.Cars.SingleOrDefault(x => x.Id == car.Id);
            oldCar.Name = car.Name;
            oldCar.Model = car.Model;
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
