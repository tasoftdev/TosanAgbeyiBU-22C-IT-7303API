namespace SchoolScheduleAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int InstructorId { get; set; }
        public string Room { get; set; }
        public string Schedule { get; set; }
        public Instructor Instructor { get; set; }
        public object CourseStudents { get; internal set; }
    }
}
