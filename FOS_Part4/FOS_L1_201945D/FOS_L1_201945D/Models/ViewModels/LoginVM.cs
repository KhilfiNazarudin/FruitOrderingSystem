using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FOS_L1_201945D.Models.ViewModels
{
    public class LoginVM
    {
       
        [Required]
        [MaxLength(256)]
        public string Username { get; set; }

       [Required]
       [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
