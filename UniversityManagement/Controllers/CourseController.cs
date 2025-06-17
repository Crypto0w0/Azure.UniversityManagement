using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Models;
using UniversityManagement.Data;

namespace UniversityManagement.Controllers
{
    public class CourseController : Controller
    {
        private readonly UniversityContext _context;

        public CourseController(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Statistics()
        {
            var courseStats = await _context.Courses
                .Select(c => new CourseStatisticsViewModel
                {
                    CourseName = c.CourseName,
                    StudentCount = c.Enrollments.Count,
                    AverageGrade = c.Enrollments.Average(e => e.Grade)
                })
                .ToListAsync();

            return View(courseStats);
        }
    }
}
