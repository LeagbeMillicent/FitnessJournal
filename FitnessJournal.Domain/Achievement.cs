namespace FitnessJournal.Domain
{
    public class Achievement
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateAchieved { get; set; }
    }
}