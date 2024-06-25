using Covadis.API.Models;
using Covadis.Shared;
using Covadis.API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Covadis.Shared.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Covadis.API.Controllers
{
    [AllowAnonymous]
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
                Password = "Confidential",
            });
            if (userDtos == null) { return NotFound(); }

            return Ok(userDtos);
            //if (users == null) { return NotFound(); }

            //UserDto[]? userDtos = [];
            //foreach (var user in users)
            //{
            //    UserDto dto = new UserDto
            //    {
            //        Email = user.Email,
            //        Name = user.Name,
            //        Password = "Confidential"
            //    };
            //    userDtos.Append(user);
            //}
        }

        [HttpGet("getUser/{id}")]
        public IActionResult GetById(int id)
        {
            var users = context.Users.FirstOrDefault(x => x.Id == id);

            return Ok(users);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
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

        [HttpGet("secret")]
        public IActionResult Secret()
        {
            return Ok("This is a secret message");
        }
    }
}
