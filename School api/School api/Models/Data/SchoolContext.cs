using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SchoolScheduleAPI;
using System.Reflection.Emit;

namespace SchoolScheduleAPI.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Mathematics", Credits = 4 },
                new Course { Id = 2, Name = "English", Credits = 3 },
                new Course { Id = 3, Name = "Physics", Credits = 4 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Abubaka", LastName = "Tosin", Age = 18, Email = "abubaka@example.com" },
                new Student { Id = 2, FirstName = "Ngozi", LastName = "Lallana", Age = 19, Email = "ngozi@example.com" },
                new Student { Id = 3, FirstName = "Oladejo", LastName = "Babaginda", Age = 20, Email = "oladejo@example.com" },
                new Student { Id = 4, FirstName = "Quinn", LastName = "Atafalah", Age = 16, Email = "quinn@example.com" }
            );
        }
    }
}
