namespace FitnessJournal.Domain
{
    public class Workout
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Duration { get; set; }  // In minutes
        public string? Intensity { get; set; }  // Scale of 1-10
        public byte[]? Image { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Rmks { get; set; }
    }

}