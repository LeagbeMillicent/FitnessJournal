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
        public string? Description { get; set; }
        public DateTime DateAchieved { get; set; }
    }
}
