using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagingTrainees_TracksAndCourses.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "The topic is required.")]
        [MaxLength(50, ErrorMessage = "The topic must be less than or equal to 50 characters.")]
        public string Topic { get; set; }

        [Range(0, 100, ErrorMessage = "The grade must be between 0 and 100.")]
        public int Grade { get; set; }


        // Navigation properties for the Trainee class

        [ForeignKey("Trainee")]
        public int TraineeID { get; set; }
        public virtual Trainee Trainee { get; set; }
        // for M:M with trainees
        //[InverseProperty("Courses")]
        //public virtual ICollection<Trainee> Trainees { get; set; }
    }
}
