using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using corvadis.API.models;

namespace corvadis.API.Context;

public class GraafschapCollegeDbContext(DbContextOptions<GraafschapCollegeDbContext> options)
: DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Auto { get; set; }

}
