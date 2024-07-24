using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Domain
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        // Personal Information
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Height { get; set; }  // In centimeters or feet/inches
        public string? Weight { get; set; }  // In kilograms or pounds
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}

