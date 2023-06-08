using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {}
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    public DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlServer("Server=localhost\\SQLEXPRESS; database=Education; Trusted_Connection=true; MultipleActiveResultSets=true; TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .Property(c => c.Price)
            .HasPrecision(14, 2);

        modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = Guid.NewGuid(),
                    Description = "Basic C# course",
                    Title = "C# from zero to hero",
                    CreationDate = DateTime.Now,
                    PublicationDate = DateTime.Now.AddYears(2),
                    Price = 56
                }
            );

        modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = Guid.NewGuid(),
                    Description = "Basic Java course",
                    Title = "Java from zero to hero",
                    CreationDate = DateTime.Now,
                    PublicationDate = DateTime.Now.AddYears(1),
                    Price = 46
                }
            );

        modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = Guid.NewGuid(),
                    Description = "Basic unit testing course for .NET",
                    Title = "XUnit from zero to hero",
                    CreationDate = DateTime.Now,
                    PublicationDate = DateTime.Now.AddYears(2),
                    Price = 35
                }
            );
    }
}
