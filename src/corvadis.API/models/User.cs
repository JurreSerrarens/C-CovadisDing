namespace corvadis.API.models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public required string Email { get; set; }
    public string Password { get; set; }
}