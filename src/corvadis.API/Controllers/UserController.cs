using corvadis.API.Context;
using corvadis.API.models;
using Covadis.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace corvadis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private CovadisDbContext context;
        public UserController(CovadisDbContext context)
        {
            this.context = context;
        }
        private static List<User> Users = new List<User>
        {
            new User {Name = "name", Email = "email", Password = "password" }
        };

        [HttpGet]
        public IActionResult Get()
        {
            var userDtos = Users.Select(user => new UserDto
            {
                Name = user.Name,
                Email = user.Email,
            });

            return Ok(userDtos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            Users.Add(user);
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
