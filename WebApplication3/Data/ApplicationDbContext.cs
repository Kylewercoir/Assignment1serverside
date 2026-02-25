using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for your entities. Initialize with null-forgiving operator to satisfy non-nullable checks.
        public DbSet<Workout> Workouts { get; set; } = null!;
        public DbSet<Exercise> Exercises { get; set; } = null!;
    }
}