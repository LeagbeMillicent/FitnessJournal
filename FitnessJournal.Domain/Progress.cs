namespace FitnessJournal.Domain
{
    public class Progress
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string?   Weight { get; set; }  // In kilograms or pounds
        public string? WorkoutStats { get; set; }  // Example: Average duration or intensity
        public string? Rmks { get; set; }
    }
}