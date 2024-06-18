using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Covadis.API.Models;

namespace Covadis.API.Context;

public class CovadisDbContext(DbContextOptions<CovadisDbContext> options)
: DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public DbSet<Car> Cars { get; set; }

    public DbSet<Ride> Rides { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

}
