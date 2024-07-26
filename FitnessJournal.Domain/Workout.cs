namespace FitnessJournal.Domain
{
    public class Workout
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTime? Duration { get; set; }  // In minutes
        public string? Intensity { get; set; }  // Scale of 1-10
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Rmks { get; set; }
    }

}