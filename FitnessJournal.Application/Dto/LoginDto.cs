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
        public string? Password { get; set; }
    }

    public class UserDto
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
