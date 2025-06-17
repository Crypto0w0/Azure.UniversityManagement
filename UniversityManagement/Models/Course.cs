using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace UniversityManagement.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        [Display(Name = "Назва курсу")]
        public string CourseName { get; set; }

        [Display(Name = "Кафедра")]
        public string Department { get; set; }

        [Display(Name = "Кредити")]
        public int Credits { get; set; } = 3;

        [Display(Name = "Викладач")]
        public string Professor { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
