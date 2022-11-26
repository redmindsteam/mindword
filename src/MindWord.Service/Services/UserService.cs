using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Service.Interfaces.Security;
using MindWord.Service.Interfaces.Services;
using MindWord.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.Service.Services
{
    public class UserService : IUserService
    {
        public async Task<(bool isSuccessful, string Message)> LoginAsync(string email, string password)
        {
            IUserRepository userRepository = new UserRepository();
            var user = await userRepository.GetByEmail(email);
            if(user != null) 
            {
                IPasswordHasher passwordHasher = new PasswordHasher();
                var result = passwordHasher.Verify(password, user.Salt, user.PasswordHash);
                if(result == true)
                {
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
    }
}
