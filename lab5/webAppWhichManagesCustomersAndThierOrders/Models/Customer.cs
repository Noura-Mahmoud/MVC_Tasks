using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webAppWhichManagesCustomersAndThierOrders.Models
{
    public enum Gender { Male, Female }
    public class Customer
    {

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        //[RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be Male or Female")]
        [EnumDataType(typeof(Gender))]

        public string Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        //[RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNum { get; set; }
    }
}