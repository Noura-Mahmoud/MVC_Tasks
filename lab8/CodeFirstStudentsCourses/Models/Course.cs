using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CodeFirstStudentsCourses.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Topic is required.")]
        public string Topic { get; set; }

        [Range(0, 100, ErrorMessage = "Course grade must be between 0 and 100.")]
        public int CourseGrade { get; set; }

        public int StudentID { get; set; }

        public Student Student { get; set; }
    }
}
