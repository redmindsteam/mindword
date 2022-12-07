using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.Domain.Constants;
using MindWord.Domain.Entities;
using System.Data.SQLite;

namespace MindWord.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SQLiteConnection _con = new SQLiteConnection(DbConstants.CONNECTION_STRING);

        public async Task<bool> CreateAsync(Category item)
        {
            try
            {
                await _con.OpenAsync();
                string query = "INSERT INTO categories(title,description,user_id)" +
                                " VALUES($title, $description, $user_id);";
                var command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {
                        new SQLiteParameter("title",item.Title),
                        new SQLiteParameter("description",item.Description),
                        new SQLiteParameter("user_id",item.UserId)
                    }
                };
                var result = await command.ExecuteNonQueryAsync();

                if (result != 0)
                {
                    return true;
                }
                else
                    return false;

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
                string query = $"delete from categories where id = {id}";
                var command = new SQLiteCommand(query, _con);
                var result = await command.ExecuteNonQueryAsync();
                if (result != 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {

                return false;
            }
            finally { _con.Close(); }
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            try
            {
                var categories = new List<Category>();
                await _con.OpenAsync();
                string query = $"SELECT * from categories";
                var command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    var category = new Category()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        UserId = reader.GetInt32(3),
                    };
                    categories.Add(category);
                }
                return categories;
            }
            catch
            {

                return new List<Category>();
            }
            finally { _con.Close(); }
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"SELECT * from categories where id = {id}";
                var command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return new Category
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        UserId = reader.GetInt32(3),
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

        public async Task<Category> GetByTitleAsync(string title)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"SELECT * from categories where  title like '{title}'";
                var command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                var result = await reader.ReadAsync();  
                if (result)
                {
                    
                    return new Category
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        UserId = reader.GetInt32(3)
                        
                        
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
        public async Task<bool> UpdateAsync(int id, Category entity)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"UPDATE categories SET title = $title, description = $description WHERE id={id};";
                var command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {
                        new SQLiteParameter("title", entity.Title),
                        new SQLiteParameter("description", entity.Description)
                    }
                };
                var result = await command.ExecuteNonQueryAsync();
                if (result != 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {

                return false;
            }
            finally { _con.Close(); }
        }
    }
}
