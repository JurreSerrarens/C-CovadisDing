using Covadis.API.Models;
using Covadis.Shared;
using Covadis.API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Covadis.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class RideController : ControllerBase
    {
        private CovadisDbContext context;
        public RideController(CovadisDbContext context) { this.context = context; }

        [HttpGet]
        public IActionResult Get()
        {
            var rideDtos = context.Rides.Include(x => x.Car).Include(x => x.User).Select(ride => new RideDto
            {
                StartPosition = ride.StartPosition,
                EndPosition = ride.EndPosition,
                StartAddress = ride.StartAddress,
                EndAddress = ride.EndAddress,
                User = ride.User.Id,
                Car = ride.Car.Id,
                Active = ride.Active
            });

            return Ok(rideDtos);
        }
        [HttpGet("RideDisplays")]
        public IActionResult GetDisplays()
        {
            var rideDtos = context.Rides.Include(x => x.Car).Include(x => x.User).Select(ride => new RideDisplay
            {
                Id = ride.Id,
                StartPosition = ride.StartPosition,
                EndPosition = ride.EndPosition,
                StartAddress = ride.StartAddress,
                EndAddress = ride.EndAddress,
                User = ride.User.Name,
                Car = ride.Car.Name,
                Active = ride.Active
            });

            return Ok(rideDtos);
        }
        [HttpGet("getRide/{id}")]
        public IActionResult GetById(int id)
        {
            var rideDto = context.Rides.FirstOrDefault(x  => x.Id == id);
            return Ok(rideDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RideDto newRide)
        {
            User? user = context.Users.FirstOrDefault(x => x.Id == newRide.User);
            Car? car = context.Cars.FirstOrDefault(x => x.Id == newRide.Car);
            if (user == null || car == null || newRide == null) { return BadRequest(); }

            Ride ride = new Ride()
            {
                Id = newRide.Id,
                StartPosition = newRide.StartPosition,
                EndPosition = newRide.EndPosition,
                StartAddress = newRide.StartAddress,
                EndAddress = newRide.EndAddress,
                User = user,
                Car = car,
                Active = newRide.Active

            };

            context.Rides.Add(ride);
            context.SaveChanges();
            return Ok();
        }

        //Update existing docent
        [HttpPut]
        public ActionResult<Ride> updateDocent(RideDto ride)
        {
            User? user = context.Users.FirstOrDefault(x => x.Id == ride.User);
            Car? car = context.Cars.FirstOrDefault(x => x.Id == ride.Car);
            if (user == null || car == null || ride == null) { return BadRequest(); }

            Ride oldRide = context.Rides.SingleOrDefault(x => x.Id == ride.Id);
            oldRide.Id = ride.Id;
            oldRide.StartPosition = ride.StartPosition;
            oldRide.EndPosition = ride.EndPosition;
            oldRide.StartAddress = ride.StartAddress;
            oldRide.EndAddress = ride.EndAddress;
            oldRide.User = user;
            oldRide.Car = car;
            oldRide.Active = ride.Active;

            context.SaveChanges();
            return Ok(oldRide);
        }

        //Remove existing docent from database
        [HttpDelete]
        public IActionResult deleteRide(int id)
        {
            context.Rides.Where(x => x.Id == id).ExecuteDelete();

            context.SaveChanges();
            return Ok();
        }
    }
}
