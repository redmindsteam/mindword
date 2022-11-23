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
                string query = @"INSERT INTO Users(Id,CreatedAt,FullName,Email,PasswordHash,Salt)" +
                     "VALUES($Id,$CreatedAt,$FullName,$Email,$PasswordHash,$Salt)";
                var command = new SQLiteCommand(query,_con);
                command.Parameters.AddWithValue("id", item.Id);
                command.Parameters.AddWithValue("CreatedAt", item.CreatedAt);
                command.Parameters.AddWithValue("FullName", item.FullName);
                command.Parameters.AddWithValue("Email", item.Email);
                command.Parameters.AddWithValue("PasswordHash", item.PasswordHash);
                command.Parameters.AddWithValue("Salt", item.Salt);
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

        public async Task<IList<User>> GetAllAsync(int skip, int take)
        {
            try
            {

                var users = new List<User>();
                await _con.OpenAsync();
                string query = $"select * from Users offset {skip} limit {take}";
                var command = new SQLiteCommand (query,_con);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var user = new User()
                    {
                        Id = reader.GetInt32("Id"),
                        CreatedAt = reader.GetDateTime("CreatedAt"),
                        FullName = reader.GetString("FullName"),
                        Email = reader.GetString("Email"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        Salt = reader.GetString("Salt")

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
                        new("Email",email)
                    }
                };
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return new User()
                    {
                        Id = reader.GetInt32("Id"),
                        CreatedAt = reader.GetDateTime("CreatedAt"),
                        FullName = reader.GetString("FullName"),
                        Email = reader.GetString("Email"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        Salt = reader.GetString("Salt")
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
                        CreatedAt = reader.GetDateTime("CreatedAt"),
                        FullName = reader.GetString("FullName"),
                        Email = reader.GetString("Email"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        Salt = reader.GetString("Salt")
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
                    "PasswordHash = $PasswordHash, Salt = $Salt" +
                    "Where Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {
                        new SQLiteParameter("Id",entity.Id),
                        new SQLiteParameter("FullName",entity.FullName),
                        new SQLiteParameter("Email", entity.Email),
                        new SQLiteParameter("PasswordHash",entity.PasswordHash),
                        new SQLiteParameter("Salt",entity.Salt)
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
