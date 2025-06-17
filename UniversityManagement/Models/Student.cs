using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace UniversityManagement.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Дата народження")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Рік вступу")]
        public int AdmissionYear { get; set; }

        [Display(Name = "Факультет")]
        public string Faculty { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}