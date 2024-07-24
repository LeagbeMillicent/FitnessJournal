using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Application.Dto
{
    public class FitnessInfoDto
    {
        public int Id { get; set; }
        public string? FitnessLevel { get; set; }
        public List<string> Goals { get; set; } = new List<string>();
        public List<string> PreferredWorkoutTypes { get; set; } = new List<string>();
    }
    public class AddFitnessInfoDto
    {
        public string? FitnessLevel { get; set; }
        public List<string> Goals { get; set; } = new List<string>();
        public List<string> PreferredWorkoutTypes { get; set; } = new List<string>();
    }

    public class UpdateFitnessInfoDto
    {
        public int Id { get; set; }
        public string? FitnessLevel { get; set; }
        public List<string> Goals { get; set; } = new List<string>();
        public List<string> PreferredWorkoutTypes { get; set; } = new List<string>();
    }
}
