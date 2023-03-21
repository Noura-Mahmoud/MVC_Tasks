using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webAppWithThreeAreas_Admin_HR_Finance_.Models
{
    public enum Gender { Male, Female}
    public class Employee
    {
        [Key]
        public int empID { get; set; }
        [Required(ErrorMessage ="You Must Enter A Name!")]
        [MaxLength(30, ErrorMessage = "The Name is Too Long!")]
        [Display(Name="Employee Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You Must Enter A UserName!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You Must Enter A Password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "You Must Enter Your Gender!")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        [DataType(DataType.Currency)]
        public double Salary { get; set; }
        [DataType(DataType.Date)]
        public DateTime joinDate { get; set; }
        [DataType (DataType.EmailAddress)]
        [Required(ErrorMessage = "You Must Enter Your Email!")]
        [Compare("email", ErrorMessage ="It's not an email")]
        public string email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public double phoneNum { get; set; }
    }
}