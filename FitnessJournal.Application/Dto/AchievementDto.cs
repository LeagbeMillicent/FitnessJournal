using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Application.Dto
{
    public class AchievementDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateAchieved { get; set; }
    } 
    public class AddAchievementDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateAchieved { get; set; }
    }
    public class UpdateAchievementDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateAchieved { get; set; }
    }
}
