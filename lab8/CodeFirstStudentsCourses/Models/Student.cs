using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace CodeFirstStudentsCourses.Models
{
    public enum Gender { Male, Female}
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be either Male or Female.")]
        public Gender Gender { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNum { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime Birthdate { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
