using Covadis.API.Models;
using Covadis.Shared;
using Covadis.API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Covadis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private CovadisDbContext context;
        public UserController(CovadisDbContext context) { this.context = context; }

        [HttpGet]
        public IActionResult Get()
        {
            var userDtos = context.Users.Select(user => new UserDto
            {
                Name = user.Name,
                Email = user.Email,
            });

            return Ok(userDtos);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var userDtos = context.Users.FirstOrDefault(x => x.Id == id);

            return Ok(userDtos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            context.Users.Add(user);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            User oldUser = context.Users.SingleOrDefault(x => x.Id == user.Id);
            oldUser.Name = user.Name;
            oldUser.Email = user.Email;
            oldUser.Password = user.Password;
            //oudeBoek.AantalBladzijden = boek.AantalBladzijden;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {

            context.Users.Where(x => x.Id == Id).ExecuteDelete();
            context.SaveChanges();
            return Ok();
        }
    }
}
