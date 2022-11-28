using MindWord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.DataAccess.Interfaces.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetByTitleAsync(string title);
    }
}
