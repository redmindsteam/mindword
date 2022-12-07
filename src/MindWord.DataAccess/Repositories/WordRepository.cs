using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.Domain.Constants;
using MindWord.Domain.Entities;
using System.Data.SQLite;

namespace MindWord.DataAccess.Repositories
{
    public class WordRepository : IWordRepository
    {
        private readonly SQLiteConnection _con = new SQLiteConnection(DbConstants.CONNECTION_STRING);

        public async Task<bool> CreateAsync(Word item)
        {
            using (var con = _con)
            {
                try
                {

                    await con.OpenAsync();
                    string query = "INSERT INTO Words(name,description,translate,voice,correct_coins," +
                                " error_coins,category_id,user_id)" +
                                " VALUES($name,$description,$translate,$voice,$correct_coins,$error_coins,$category_id,$user_id)";
                    var command = new SQLiteCommand(query, con)
                    {
                        Parameters =
                    {
                        new SQLiteParameter("$name", item.Name),
                        new SQLiteParameter("$description", item.Description),
                        new SQLiteParameter("$translate",item.Translate),
                        new SQLiteParameter("$voice",item.AudioPath),
                        new SQLiteParameter("$correct_coins",item.CorrectCoins),
                        new SQLiteParameter("$error_coins",item.ErrorCoins),
                        new SQLiteParameter("$category_id",item.CategoryId),
                        new SQLiteParameter("$user_id",item.UserId)
                    }
                    };
                   
                    var result = await command.ExecuteNonQueryAsync();

                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    { return false; }

                }
                catch
                {
                    return false;
                }
                finally
                {
                    if (con.State != System.Data.ConnectionState.Closed)
                        await con.CloseAsync();
                }
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"delete from words WHERE id = {id};";
                var command = new SQLiteCommand(query, _con);
                var result = await command.ExecuteNonQueryAsync();
                if (result != 0) { return true; }
                else { return false; }
            }
            catch
            {

                return false;
            }
            finally { _con.Close(); }
        }

        public async Task<IList<Word>> GetAllAsync()
        {
            try
            {
                var words = new List<Word>();
                await _con.OpenAsync();
                string query = $"select * from Words ";
                var command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var word = new Word()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Translate = reader.GetString(3),
                        AudioPath = reader.GetString(4),
                        CorrectCoins = reader.GetInt32(5),
                        ErrorCoins = reader.GetInt32(6),
                        CategoryId = reader.GetInt32(7),
                        UserId = reader.GetInt32(8)

                    };

                    words.Add(word);
                }
                return words;
            }
            catch
            {
                return new List<Word>();
            }
            finally { _con.Close(); }

        }

        public async Task<Word> GetByIdAsync(int id)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"select * from words where id = {id}";
                var command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                return new Word()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Translate = reader.GetString(3),
                    AudioPath = reader.GetString(4),
                    CorrectCoins = reader.GetInt32(5),
                    ErrorCoins = reader.GetInt32(6),
                    CategoryId = reader.GetInt32(7),
                    UserId = reader.GetInt32(8),

                };

            }
            catch
            {

                return null!;
            }
            finally { await _con.CloseAsync(); }

        }

        public async Task<bool> UpdateAsync(int id, Word item)
        {
            try
            {
                await _con.OpenAsync();
                string query = "UPDATE words set name = $name, description = $description,translate = $translate," +
                                $"voice = $voice, correct_coins = $correct_coins, error_coins = $error_coins where id = {id}";
                var command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {

                        new SQLiteParameter("name", item.Name),
                        new SQLiteParameter("description", item.Description),
                        new SQLiteParameter("translate",item.Translate),
                        new SQLiteParameter("voice",item.AudioPath),
                        new SQLiteParameter("correct_coins",item.CorrectCoins),
                        new SQLiteParameter("error_coins",item.ErrorCoins)
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
