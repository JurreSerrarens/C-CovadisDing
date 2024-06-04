namespace Covadis.API.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public required string Email { get; set; }
    public string Password { get; set; }
}