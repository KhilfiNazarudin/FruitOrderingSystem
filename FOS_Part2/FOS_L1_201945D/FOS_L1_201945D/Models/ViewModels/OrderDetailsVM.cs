using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FOS_L1_201945D.Models.ViewModels
{
    public class OrderDetailsVM
    {
        [Required(ErrorMessage = "Please enter an address")]
        [StringLength(200, ErrorMessage = "Max Length of address is 200 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a date")]
        [RegularExpression(@"[689]\d{7}")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage ="Please enter a valid date")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Date should be in the future.")]
        public DateTime Date { get; set; }

        public OrderVM OrderVM { get; set; }
        public class FutureDateAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                return value != null && (DateTime)value > DateTime.Now;
            }
        }

    }
}
