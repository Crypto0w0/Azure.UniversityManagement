using System.ComponentModel.DataAnnotations;

namespace UniversityManagement.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        [Display(Name = "Дата запису")]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        [Range(0, 100)]
        [Display(Name = "Оцінка")]
        public int? Grade { get; set; }

        [Display(Name = "Статус")]
        public string Status { get; set; } = "In Progress";

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
