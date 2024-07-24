using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Domain
{
    public class FitnessInformation
    {
        public int Id { get; set; }
        public string? FitnessLevel { get; set; }
        public List<string> Goals { get; set; } = new List<string>();
        public List<string> PreferredWorkoutTypes { get; set; } = new List<string>();
    }
}
