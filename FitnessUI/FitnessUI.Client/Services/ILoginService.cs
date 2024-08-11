using FitnessJournal.Application.Dto;

namespace Fitness.Blazor.Client.Services
{
    public interface ILoginService
    {
        Task<LoginDto> CreateLoginAsync(LoginDto newLogin);
    }
}
