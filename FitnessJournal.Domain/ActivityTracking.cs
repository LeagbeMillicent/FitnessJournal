using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Domain
{
    public class ActivityTracking
    {
        public int Id { get; set; }
        public List<Workout> Workouts { get; set; } = new List<Workout>();
        public List<Progress> Progress { get; set; } = new List<Progress>();
        public List<Achievement> Achievements { get; set; } = new List<Achievement>();
    }
}
