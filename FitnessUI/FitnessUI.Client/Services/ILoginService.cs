using FitnessJournal.Application.Dto;

namespace FitnessUI.Client.Services
{
    public interface ILoginService
    {
        Task<LoginDto> CreateLoginAsync(LoginDto newLogin);
    }
}
