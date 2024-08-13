using FitnessJournal.Application.Dto;
using FitnessJournal.Domain;
using System.Net.Http.Json;

namespace FitnessUI.Client.Services
{
    public class WorkService : IWorkoutService
    {
        private readonly HttpClient _httpClient;

        public WorkService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<WorkoutDto> CreateWorkoutAsync(WorkoutDto newWorkout)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Workout", newWorkout);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<WorkoutDto>();
        }

        public async Task DeleteWorkoutAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Workout");
            response.EnsureSuccessStatusCode();
        }

        public async Task<WorkoutDto> GetWorkoutByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<WorkoutDto>($"api/Workout");
        }

        public async Task<IEnumerable<WorkoutDto>> GetWorkoutsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<WorkoutDto>>("api/Workout/GetAllWorkout");
        }

        public async Task UpdateWorkoutAsync(WorkoutDto updatedWorkout)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Workout", updatedWorkout);
            response.EnsureSuccessStatusCode();
        }
    }
}
