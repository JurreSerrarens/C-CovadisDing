namespace Covadis.API.Seeders;

using Covadis.API.Models;
using Covadis.API.Context;
using Covadis.Shared.Constants;

using System.Data;

public static class UserSeeder
{
    public static void Seed(CovadisDbContext dbContext)
    {
        var existingUsers = dbContext.Users
            .Select(x => x.Email)
            .ToList();

        var roles = dbContext.Roles.ToList();

        var users = new List<User>
        {
            new()
            {
                Name = "Bryan Schoot",
                Email = "b.schoot@example.com",
                Password =  BCrypt.Net.BCrypt.HashPassword("Password123!"),
                Roles = [roles.Find(x => x.Name == Roles.Administrator)!]
            },
            new()
            {
                Name = "John Doe",
                Email = "j.doe@example.com",
                Password =  BCrypt.Net.BCrypt.HashPassword("Password123!"),
                Roles = [roles.Find(x => x.Name == Roles.Employee)!]
            },
            new()
            {
                Name = "Greg Le Egg",
                Email = "greg@egg.egg",
                Password =  BCrypt.Net.BCrypt.HashPassword("EggEggEgg"),
                Roles = [roles.Find(x => x.Name == Roles.Administrator)!]
            }
        };

        var usersToAdd = users
            .Where(x => !existingUsers.Contains(x.Email))
            .ToList();

        dbContext.Users.AddRange(usersToAdd);
        dbContext.SaveChanges();
    }
}