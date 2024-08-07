using FitnessJournal.Application.Dto;
using System.Net.Http.Json;

namespace Fitness.Blazor.Client.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginDto> CreateLoginAsync(LoginDto newLogin)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Login/Login", newLogin);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<LoginDto>();
        }
    }
}
