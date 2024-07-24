using FitnessJournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Application.Dto
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public WorkoutType Type { get; set; }
        public string? Duration { get; set; }  // In minutes
        public string? Intensity { get; set; }  // Scale of 1-10
        public DateTime Date { get; set; }
        public string? Rmks { get; set; }
    }
    
    public class AddWorkoutDto
    {
        public WorkoutType Type { get; set; }
        public string? Duration { get; set; }  // In minutes
        public string? Intensity { get; set; }  // Scale of 1-10
        public DateTime Date { get; set; }
        public string? Rmks { get; set; }
    }
    public class UpdateWorkoutDto
    {
        public int Id { get; set; }
        public WorkoutType Type { get; set; }
        public string? Duration { get; set; }  // In minutes
        public string? Intensity { get; set; }  // Scale of 1-10
        public DateTime Date { get; set; }
        public string? Rmks { get; set; }
    }
}
