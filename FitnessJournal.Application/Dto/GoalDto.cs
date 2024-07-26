using FitnessJournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Application.Dto
{
    public class GoalDto
    {
        public int GoalId { get; set; }
        public string? GoalName { get; set; }
        public List<Workout> Workout { get; set; } = [];
        public bool IsAchieved { get; set; }

    }
    public class AddGoalDto
    {
        public string? GoalName { get; set; }
        public List<Workout> Workout { get; set; } = [];
        public bool IsAchieved { get; set; }

    }
    public class UpdateGoalDto
    {
        public int GoalId { get; set; }
        public string? GoalName { get; set; }
        public List<Workout> Workout { get; set; } = [];
        public bool IsAchieved { get; set; }

    }
}
