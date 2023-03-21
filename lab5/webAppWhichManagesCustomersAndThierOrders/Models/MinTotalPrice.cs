using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webAppWhichManagesCustomersAndThierOrders.Models
{
    public class MinTotalPrice : ValidationAttribute
    {
        double minVal;
        public MinTotalPrice(double val) { minVal = val; }
        public override bool IsValid(object value)
        {
            if (value == null) { return false; }
            else
            {
                if (value is double)
                {
                    return (double)value > minVal;
                }
                else
                    return false;
            }
        }

    }
}