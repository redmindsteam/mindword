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
using System.Data.Common;
using System.Data.SqlClient;

namespace MindWord.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SQLiteConnection _con = new SQLiteConnection(DbConstants.CONNECTION_STRING);
        public async Task<bool> CreateAsync(User item)
        {
            try
            {
               await _con.OpenAsync();
                string query = @"INSERT INTO Users(CreatedAt,FullName,Email,PasswordHash,Salt,account_image_path)" +
                     "VALUES($CreatedAt,$FullName,$Email,$PasswordHash,$Salt,$account_image_path);";
                var command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {
                        new SQLiteParameter("CreatedAt", item.CreatedAt),
                        new SQLiteParameter("FullName", item.FullName),
                        new SQLiteParameter("Email", item.Email),
                        new SQLiteParameter("PasswordHash", item.PasswordHash),
                        new SQLiteParameter("Salt", item.Salt),
                        new SQLiteParameter("account_image_path", item.AccountImagePath)
                    }
                };
                
                var result = await command.ExecuteNonQueryAsync();
                return result > 0;
            }
            catch 
            {
                return false;
            }
            finally { _con.Close(); }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"DELETE FROM Users where id = {id}";
                var command = new SQLiteCommand(query,_con);
                var result = await command.ExecuteNonQueryAsync();
                if(result > 0)
                    return true;
                else
                    return false;

            }
            catch 
            {

                return false;
            }
            finally { _con.Close(); }
        }

        public async Task<IList<User>> GetAllAsync()
        {
            try
            {

                var users = new List<User>();
                await _con.OpenAsync();
                string query = $"SELECT * FROM Users ;";
                var command = new SQLiteCommand (query,_con);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var user = new User()
                    {
                        Id = reader.GetInt32("Id"),
                        CreatedAt = DateTime.Parse(reader.GetString("CreatedAt")),
                        FullName = reader.GetString("FullName"),
                        Email = reader.GetString("Email"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        Salt = reader.GetString("Salt"),
                        AccountImagePath = reader.GetDataTypeName("account_image_path")
                     

                    };
                    users.Add(user);
                }

                return users;
            }
            catch 
            {

                return new List<User>();
            }
            finally { _con.Close(); }
        }

        public async Task<User> GetByEmail(string email)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"SELECT * FROM Users where Email = $email";
                SQLiteCommand command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {
                        new SQLiteParameter ("email",email)
                    }
                };
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return new User()
                    {
                        Id = reader.GetInt32("Id"),
                        CreatedAt = DateTime.Parse(reader.GetString("CreatedAt")),
                        FullName = reader.GetString("FullName"),
                        Email = reader.GetString("Email"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        Salt = reader.GetString("Salt"),
                        AccountImagePath = reader.GetString("account_image_path")

                        
                    };
                }
                else 
                    return null!;
            }
            catch 
            {

                return null!;
            }
            finally { _con.Close(); }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"select * from Users where Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                if(await reader.ReadAsync())
                {
                    return new User()
                    {
                        Id = reader.GetInt32("Id"),
                        CreatedAt = DateTime.Parse(reader.GetString("CreatedAt")),
                        FullName = reader.GetString("FullName"),
                        Email = reader.GetString("Email"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        Salt = reader.GetString("Salt"),
                        AccountImagePath = reader.GetString("account_image_path")
                    };
                }
                else return null!;
            }
            catch 
            {

                return null!;
            }
            finally { _con.Close(); }
        }

        public async Task<bool> UpdateAsync(int id, User entity)
        {
            try
            {
               await  _con.OpenAsync();
                string query = $"update Users set " +
                    "FullName = $FullName, Email = $Email," +
                    " PasswordHash = $PasswordHash, Salt = $Salt, account_image_path = $account_image_path " +
                    $"Where Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {
                       
                        new SQLiteParameter("FullName",entity.FullName),
                        new SQLiteParameter("Email", entity.Email),
                        new SQLiteParameter("PasswordHash",entity.PasswordHash),
                        new SQLiteParameter("Salt",entity.Salt),
                        new SQLiteParameter("account_image_path",entity.AccountImagePath)
                    }
                };
                int result = await command.ExecuteNonQueryAsync();
                if(result == 0)
                    return false;
                else
                    return true;
            }
            catch 
            {

                return false;
            }
            finally { _con.Close(); }
        }
    }
}
