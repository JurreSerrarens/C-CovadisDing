using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using corvadis.API.models;
using corvadis.API.Models;

namespace corvadis.API.Context;

public class CovadisDbContext(DbContextOptions<CovadisDbContext> options)
: DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Ride> Rides { get; set; }
}
