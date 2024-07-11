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
    public class StudentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            var students = _context.Students
                .Include(s => s.CourseStudents)
                .ThenInclude(cs => cs.Course)
                .ToList();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _context.Students
                .Include(s => s.CourseStudents)
                .ThenInclude(cs => cs.Course)
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> PostStudent([FromBody] Student newStudent)
        {
            _context.Students.Add(newStudent);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetStudentById), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut("{id}")]
        public ActionResult PutStudent(int id, [FromBody] Student updatedStudent)
        {
            if (id != updatedStudent.Id)
            {
                return BadRequest("Id mismatch between route parameter and body.");
            }

            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.Age = updatedStudent.Age;
            student.Email = updatedStudent.Email;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
