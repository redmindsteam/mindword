using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using MindWord.Domain.Constants;

namespace MindWord.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SQLiteConnection _con = new SQLiteConnection(DbConstants.CONNECTION_STRING);
        public  Task<bool> CreateAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
