using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagingTrainees_TracksAndCourses.Models
{
    public class Track
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [MaxLength(50, ErrorMessage = "The name must be less than or equal to 50 characters.")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "The description must be less than or equal to 200 characters.")]
        public string Description { get; set; }

        // Navigation property for the Trainee class
        [InverseProperty("Track")]
        public virtual ICollection<Trainee> Trainees { get; set; }
    }
}
