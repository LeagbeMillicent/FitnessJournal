using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Domain
{
    public class Goal
    {
        public int GoalId { get; set; }
        public string? GoalName { get; set; }
        public List<Workout> Workout { get; set; } = [];
        public bool IsAchieved { get; set; }

    }
}
