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
    public class InstructorsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public InstructorsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Instructor>> GetInstructors()
        {
            var instructors = _context.Instructors.Include(i => i.Courses).ToList();
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public ActionResult<Instructor> GetInstructorById(int id)
        {
            var instructor = _context.Instructors.Include(i => i.Courses).FirstOrDefault(i => i.Id == id);
            if (instructor == null)
            {
                return NotFound();
            }
            return Ok(instructor);
        }

        [HttpPost]
        public ActionResult<Instructor> PostInstructor([FromBody] Instructor newInstructor)
        {
            _context.Instructors.Add(newInstructor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetInstructorById), new { id = newInstructor.Id }, newInstructor);
        }

        [HttpPut("{id}")]
        public ActionResult PutInstructor(int id, [FromBody] Instructor updatedInstructor)
        {
            if (id != updatedInstructor.Id)
            {
                return BadRequest("Id mismatch between route parameter and body.");
            }

            var instructor = _context.Instructors.Find(id);
            if (instructor == null)
            {
                return NotFound();
            }

            instructor.FirstName = updatedInstructor.FirstName;
            instructor.LastName = updatedInstructor.LastName;
            instructor.Email = updatedInstructor.Email;
            instructor.Department = updatedInstructor.Department;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteInstructor(int id)
        {
            var instructor = _context.Instructors.Find(id);
            if (instructor == null)
            {
                return NotFound();
            }

            _context.Instructors.Remove(instructor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
