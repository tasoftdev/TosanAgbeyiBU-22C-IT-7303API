using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleAPI.Data;
using SchoolScheduleAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolScheduleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly SchoolContext _context;

        public CoursesController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            var courses = _context.Courses.Include(c => c.Instructor).ToList();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseById(int id)
        {
            var course = _context.Courses.Include(c => c.Instructor).FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public ActionResult<Course> PostCourse([FromBody] Course newCourse)
        {
            _context.Courses.Add(newCourse);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCourseById), new { id = newCourse.Id }, newCourse);
        }

        [HttpPut("{id}")]
        public ActionResult PutCourse(int id, [FromBody] Course updatedCourse)
        {
            if (id != updatedCourse.Id)
            {
                return BadRequest("Id mismatch between route parameter and body.");
            }

            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            course.Name = updatedCourse.Name;
            course.Credits = updatedCourse.Credits;
            course.InstructorId = updatedCourse.InstructorId;
            course.Room = updatedCourse.Room;
            course.Schedule = updatedCourse.Schedule;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
