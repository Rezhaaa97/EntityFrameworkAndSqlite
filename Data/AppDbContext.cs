
using LECTURE4.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().HasData(
            new User {Id = 1, Name = "Rejwan Raouf", Email="rejwan@test.no"},
            new User {Id = 2, Name = "Frode Abrahamsen", Email = "frode@test.no"}
        );
    }

}