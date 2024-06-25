using Covadis.API.Models;
using Covadis.Shared;
using Covadis.API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Covadis.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private CovadisDbContext context;
        public ReservationController(CovadisDbContext context) { this.context = context; }

        [HttpGet("Reservations")]
        public IActionResult Get()
        {
            var value = context.Reservations.Include(x => x.Car).Include(x => x.User).Select(res => new ReservationDto
            {
                Id = res.Id,
                From = res.From,
                To = res.To,
                User = res.User.Id,
                Car = res.Car.Id
            });
            return Ok(value);
        }
        [HttpGet("ReservationsDisplay")]
        public IActionResult GetDisplay()
        {
            var value = context.Reservations.Include(x => x.Car).Include(x => x.User).Select(res => new ReservationDisplay
            {
                Id = res.Id,
                From = res.From,
                To = res.To,
                User = res.User.Name,
                Car = res.Car.Name
            });
            return Ok(value);
        }

        [HttpGet("getReservation/{id}")]
        public IActionResult GetById(int id)
        {
            var value = context.Reservations.FirstOrDefault(x => x.Id == id);
            return Ok(value);
        }

        //[HttpPost]
        //public IActionResult Post([FromBody] Reservation res)
        //{
        //    context.Reservations.Add(res);
        //    context.SaveChanges();
        //    return Ok();
        //}
        [HttpPost]
        public IActionResult Post([FromBody] ReservationDto res)
        {
            User? user = context.Users.FirstOrDefault(x => x.Id == res.User);
            Car? car = context.Cars.FirstOrDefault(x => x.Id == res.Car);
            if (user == null || car == null || res == null) { return BadRequest(); }

            Reservation reservation = new Reservation()
            {
                Id = res.Id,
                From = res.From,
                To = res.To,
                User = user,
                Car = car
            };

            context.Reservations.Add(reservation);
            context.SaveChanges();
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
