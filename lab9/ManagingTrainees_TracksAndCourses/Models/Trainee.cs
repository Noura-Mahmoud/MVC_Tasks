using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace ManagingTrainees_TracksAndCourses.Models
{

    public enum Gender {Male,Female}
    public class Trainee
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [MaxLength(50, ErrorMessage = "The name must be less than or equal to 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The gender is required.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "The email is required.")]
        [EmailAddress(ErrorMessage = "The email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The mobile number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "The mobile number must be exactly 10 digits.")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "The birthdate is required.")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        // Navigation properties for the Track and courses
        public virtual ICollection<Course> Courses { get; set; }

        [ForeignKey("Track")]
        public int TrackID { get; set; }
        public virtual Track Track { get; set; }
    }
}
