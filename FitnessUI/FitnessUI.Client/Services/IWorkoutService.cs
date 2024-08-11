using FitnessJournal.Application.Dto;
namespace Fitness.Blazor.Client.Services
{
    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutDto>> GetWorkoutsAsync();
        Task<WorkoutDto> GetWorkoutByIdAsync(int id);
        Task<WorkoutDto> CreateWorkoutAsync(WorkoutDto newWorkout);
        Task UpdateWorkoutAsync(WorkoutDto updatedWorkout);
        Task DeleteWorkoutAsync(int id);
    }
}
