using Microsoft.EntityFrameworkCore;
using SchoolScheduleAPI.Models;

namespace SchoolScheduleAPI.Model
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Mathematics", Credits = 4, InstructorId = 1, Room = "100", Schedule = "Mon,Tue,Fri 8:00 - 11:00" },
                new Course { Id = 2, Name = "English", Credits = 3, InstructorId = 2, Room = "101", Schedule = "Mon,Wed 2:00 - 3:00" },
                new Course { Id = 3, Name = "Physics", Credits = 4, InstructorId = 3, Room = "111", Schedule = "Wed 8:00 - 10:00" },
                new Course { Id = 4, Name = "Chemistry", Credits = 3, InstructorId = 4, Room = "100", Schedule = "Mon,Tue,Thur" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Abubaka", LastName = "Tosin", Age = 18, Email = "abubaka@example.com" },
                new Student { Id = 2, FirstName = "Ngozi", LastName = "Lallana", Age = 19, Email = "ngozi@example.com" },
                new Student { Id = 3, FirstName = "Oladejo", LastName = "Babaginda", Age = 20, Email = "oladejo@example.com" },
                new Student { Id = 4, FirstName = "Quinn", LastName = "Atafalah", Age = 16, Email = "quinn@example.com" }
            );

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, FirstName = "Ogozie", LastName = "Opina", Email = "ogozie@example.com", Department = "Mathematics" },
                new Instructor { Id = 2, FirstName = "Nnamada", LastName = "Kokororku", Email = "nnamada@example.com", Department = "English" },
                new Instructor { Id = 3, FirstName = "Feron", LastName = "Enumerade", Email = "feron@example.com", Department = "Physics" },
                new Instructor { Id = 4, FirstName = "Maduka", LastName = "Uriel", Email = "maduka@example.com", Department = "Chemistry" }
            );
        }
    }
}
