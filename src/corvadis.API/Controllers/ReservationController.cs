using Covadis.API.Models;
using Covadis.Shared;
using Covadis.API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Covadis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private CovadisDbContext context;
        public ReservationController(CovadisDbContext context) { this.context = context; }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var value =  context.Reservations;
            return Ok(value);
        }
        [HttpGet]
        public IActionResult GetBy(int id)
        {
            var value = context.Reservations.FirstOrDefault(x => x.Id == id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Reservation res)
        {
            context.Reservations.Add(res);
            return Ok();
        }

        //Update existing docent
        [HttpPut]
        public ActionResult<Reservation> Update(Reservation res)
        {
            Reservation oldRes = context.Reservations.SingleOrDefault(x => x.Id == res.Id);
            oldRes.From = res.From;
            oldRes.To = res.To;
            oldRes.Car = res.Car;
            oldRes.User = res.User;
            context.SaveChanges();
            return Ok(oldRes);
        }

        //Remove existing docent from database
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            context.Reservations.Where(x => x.Id == id).ExecuteDelete();

            context.SaveChanges();
            return Ok();
        }
    }
}
