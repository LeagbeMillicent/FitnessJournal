namespace FitnessJournal.Domain
{
    public class Workout
    {
        public int Id { get; set; }
        public WorkoutType Type { get; set; }
        public string? Duration { get; set; }  // In minutes
        public string? Intensity { get; set; }  // Scale of 1-10
        public DateTime Date { get; set; }
        public string? Rmks { get; set; }
    }


    public enum WorkoutType
    {
        Cardio,
        StrengthTraining,
        HIIT,
        Yoga,
        Pilates,
        CrossFit,
        DanceFitness,
        MartialArts,
        FlexibilityAndMobility,
        SportsSpecificTraining
    }

}