namespace Covadis.API.Seeders;

using Covadis.API.Context;

public static class Seeder
{
    public static void Seed(this CovadisDbContext dbContext)
    {
        RoleSeeder.Seed(dbContext);
        UserSeeder.Seed(dbContext);
    }
}