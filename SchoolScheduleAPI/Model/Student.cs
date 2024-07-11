using SchoolScheduleAPI.Model;

namespace SchoolScheduleAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public ICollection<CourseStudent> CourseStudents { get; set; }
    }
}
