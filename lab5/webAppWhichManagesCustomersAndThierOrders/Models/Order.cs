using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webAppWhichManagesCustomersAndThierOrders.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Total price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Total price must be a positive value")]
        // Custom dataAnnotation, and apply it on your classes
        [MinTotalPrice(3000, ErrorMessage ="Total Price must be more than 3000$")]
        public double TotalPrice { get; set; }

        [ForeignKey("Customer")]
        public int CustID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}