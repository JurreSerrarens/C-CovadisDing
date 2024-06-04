using Covadis.API.Models;
using Covadis.Shared;
using Covadis.API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Covadis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RideController : ControllerBase
    {
        private CovadisDbContext context;
        public RideController(CovadisDbContext context) { this.context = context; }

        [HttpGet]
        public IActionResult Get()
        {
            var rideDtos = context.Rides.Select(ride => new RideDto
            {
                StartPosition = ride.StartPosition,
                EndPosition = ride.EndPosition,
                Destination = ride.Destination,
                Active = ride.Active
            });

            return Ok(rideDtos);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var rideDtos = context.Rides.FirstOrDefault(x  => x.Id == id);

            return Ok(rideDtos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Ride ride)
        {
            context.Rides.Add(ride);
            return Ok();
        }

        //Update existing docent
        [HttpPut]
        public ActionResult<Ride> updateDocent(Ride ride)
        {
            Ride oldDocent = context.Rides.SingleOrDefault(x => x.Id == ride.Id);
            oldDocent.StartPosition = ride.StartPosition;
            oldDocent.EndPosition = ride.EndPosition;
            oldDocent.Destination = ride.Destination;
            oldDocent.Active = ride.Active;

            context.SaveChanges();
            return Ok(oldDocent);
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
