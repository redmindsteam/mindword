using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.DataAccess.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<bool> CreateAsync(T item);
        Task<bool> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<IList<T>> GetAllAsync();
    }
}
