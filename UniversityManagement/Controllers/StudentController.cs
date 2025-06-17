using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Models;
using UniversityManagement.Data;

namespace UniversityManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly UniversityContext _context;

        public StudentController(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> StudentsWithCourses()
        {
            var students = await _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .ToListAsync();

            return View(students);
        }

        public async Task<IActionResult> TopStudents()
        {
            var topStudents = await _context.Enrollments
                .Where(e => e.Grade > 90)
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();

            return View(topStudents);
        }
    }
}
