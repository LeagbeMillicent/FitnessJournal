using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Application.Dto
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public List<WorkoutDto> Workouts { get; set; } = new List<WorkoutDto>();
        public List<ProgressDto> Progress { get; set; } = new List<ProgressDto>();
        public List<AchievementDto> Achievements { get; set; } = new List<AchievementDto>();
    }
}
