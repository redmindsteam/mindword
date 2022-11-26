using MindWord.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.Service.Interfaces.Services
{
    public interface IUserService
    {
        Task<(bool isSuccessful, string Message)> LoginAsync(string email, string password);
        Task<(bool isSuccessful, string Message)> RegisterAsync(UserViewModel viewModel);
    }
}
