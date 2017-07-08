using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Assignment2.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Your name must be atleast 2 characters long", MinimumLength = 2)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Your name must be atleast 2 characters long", MinimumLength = 2)]
        public string Lastname { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
