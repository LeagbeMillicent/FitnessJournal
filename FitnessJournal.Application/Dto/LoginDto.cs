using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Application.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }    
    public class RegisterDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? Email { get; set; }
        [Required(ErrorMessage="Password is required")]
        [DataType(DataType.Password)]
        [MaxLength(8,ErrorMessage="Password should be 8 characters long")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Confirmation Password is required")]
        [Compare ("Password", ErrorMessage ="Password does not match")]
        [DataType (DataType.Password)]

        public string? ConfirmPassword { get; set; }
    }

    public class userProfile
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        // Personal Information
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Height { get; set; }  // In centimeters or feet/inches
        public string? Weight { get; set; }
    }
}
