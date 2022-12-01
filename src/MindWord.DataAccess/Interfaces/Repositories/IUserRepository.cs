using MindWord.Domain.Entities;

namespace MindWord.DataAccess.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
