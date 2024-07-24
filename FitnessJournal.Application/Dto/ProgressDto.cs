using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Application.Dto
{
    public class ProgressDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Weight { get; set; }  // In kilograms or pounds
        public string? WorkoutStats { get; set; }  // Example: Average duration or intensity
        public string? Rmks { get; set; }
    }
    public class AddProgressDto
    {
        public DateTime Date { get; set; }
        public string? Weight { get; set; }  // In kilograms or pounds
        public string? WorkoutStats { get; set; }  // Example: Average duration or intensity
        public string? Rmks { get; set; }
    }
    public class UpdateProgressDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Weight { get; set; }  // In kilograms or pounds
        public string? WorkoutStats { get; set; }  // Example: Average duration or intensity
        public string? Rmks { get; set; }
    }
}
