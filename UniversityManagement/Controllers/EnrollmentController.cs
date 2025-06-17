using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Models;
using UniversityManagement.Data;

namespace UniversityManagement.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly UniversityContext _context;

        public EnrollmentController(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var enrollments = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();

            return View(enrollments);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["CourseId"] = await _context.Courses.ToListAsync();
            ViewData["StudentId"] = await _context.Students.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,CourseId,Grade,Status")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                enrollment.EnrollmentDate = DateTime.Now;
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CourseId"] = await _context.Courses.ToListAsync();
            ViewData["StudentId"] = await _context.Students.ToListAsync();
            return View(enrollment);
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
        public async Task<IActionResult> CourseStatistics()
        {
            var statistics = await _context.Courses
                .Select(c => new CourseStatisticsViewModel
                {
                    CourseName = c.CourseName,
                    StudentCount = c.Enrollments.Count,
                    AverageGrade = c.Enrollments.Average(e => e.Grade)
                })
                .ToListAsync();

            return View(statistics);
        }
    }
}
