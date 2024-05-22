using System.Collections.Generic;
using Covadis.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Covadis.API.Context;

public class GraafschapCollegeDbContext(DbContextOptions<GraafschapCollegeDbContext> options)
: DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Auto { get; set; }
    public DbSet<Role> Roles { get; set; }
}