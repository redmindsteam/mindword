using MindWord.Domain.Entities;

namespace MindWord.DataAccess.Interfaces.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetByTitleAsync(string title);
    }
}
