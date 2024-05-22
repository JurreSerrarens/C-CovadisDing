using Microsoft.EntityFrameworkCore;

namespace Covadis.API.Models;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public required string Email { get; set; }
    public string Password { get; set; }
    public virtual ICollection<Role> Roles { get; set; }
}