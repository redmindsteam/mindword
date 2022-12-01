using MindWord.Service.ViewModel;

namespace MindWord.Service.Interfaces.Services
{
    public interface IUserService
    {
        Task<(bool isSuccessful, string Message)> LoginAsync(string email, string password);
        Task<(bool isSuccessful, string Message)> RegisterAsync(UserViewModel viewModel);
    }
}
