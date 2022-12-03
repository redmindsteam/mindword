using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Domain.Entities;
using MindWord.Service.Attributes;
using MindWord.Service.Interfaces.Security;
using MindWord.Service.Interfaces.Services;
using MindWord.Service.Security;
using MindWord.Service.ViewModel;

namespace MindWord.Service.Services
{
    public class UserService : IUserService
    {
        public async Task<(bool isSuccessful, string Message)> LoginAsync(string email, string password)
        {
            IUserRepository userRepository = new UserRepository();
            var user = await userRepository.GetByEmail(email);
            if (user != null)
            {
                IPasswordHasher passwordHasher = new PasswordHasher();
                var result = passwordHasher.Verify(password, user.Salt, user.PasswordHash);
                if (result == true)
                {
                    IdentitySingelton.SaveId(user.Id);  
                    return (true, " ");
                }
                else
                {
                    return (false, "Password is wrong!");
                }
            }
            else
            {
                return (false, "Email is wrong!");
            }
        }

        public async Task<(bool isSuccessful, string Message)> RegisterAsync(UserViewModel viewModel)
        {
            IUserRepository userRepository = new UserRepository();
            EmailAttribute emailcheck = new EmailAttribute();
            var result = emailcheck.IsValid(viewModel.Email);
            if (result.isSuccessful == true)
            {
                StrongPasswordAttribute strongPassword = new StrongPasswordAttribute();
                var res = strongPassword.IsValid(viewModel.Password);
                if (res.isSuccessful == true)
                {
                    PasswordHasher hasher = new PasswordHasher();
                    User user = new User();
                    user.Email = viewModel.Email;
                    user.FullName = viewModel.FullName;
                    user.AccountImagePath = viewModel.AccountImagePath;
                    var HashSalt = hasher.Hash(viewModel.Password);
                    user.PasswordHash = HashSalt.passwordHash;
                    user.Salt = HashSalt.salt;
                    var createresult = await userRepository.CreateAsync(user);
                    if (createresult == true)
                    {
                        return (true, "Successfully");
                    }
                    else
                    {
                        return (false, "User not created");
                    }
                }
                else
                {
                    return (false, result.Message);
                }
            }
            else
            {
                return (false, result.Message);
            }
        }
    }
}
