using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FOS_L1_201945D.Models.ViewModels
{
    public class RegisterVM
    {

        [Required(ErrorMessage = "Please enter a Name")]
        [Display(Name ="First Name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please enter Username")]
        [MaxLength(256)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter Phone number")]
        [MaxLength(8) , MinLength(8)]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter Email Address")]
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        [MaxLength(20),MinLength(9)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="Please confirm Password")]
        [MaxLength(20), MinLength(9)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="The password does not match the confirmation password.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }




}
}
