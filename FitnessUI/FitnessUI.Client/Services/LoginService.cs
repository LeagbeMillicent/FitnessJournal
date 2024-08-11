using FitnessJournal.Application.Dto;
using System.Net.Http.Json;
using static FitnessUI.Client.Pages.Login;

namespace Fitness.Blazor.Client.Services
{
    public class LoginService 
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
