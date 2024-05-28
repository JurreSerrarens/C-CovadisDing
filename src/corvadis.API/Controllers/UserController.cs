using Covadis.Shared;
using Microsoft.AspNetCore.Mvc;

namespace corvadis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
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
    }
}
