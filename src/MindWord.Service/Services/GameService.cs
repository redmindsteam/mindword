using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Domain.Entities;

namespace MindWord.Service.Services
{
    public class GameService
    {
        public async Task<List<List<Word>>> RandomTestAsync()
        {
            List<List<Word>> test = new List<List<Word>>();
            IWordRepository repository = new WordRepository();
            var words = (await repository.GetAllAsync()).ToList();

            for (int i = 0; i < 30; i++)
            {
                List<Word> word = new List<Word>();
                for (int j = 0; j < 4; j++)
                {
                k:
                    Random random = new Random();
                    int rand = random.Next(0, words.Count);
                    if (CheckList(word, words[rand]))
                        word.Add(words[rand]);
                    else
                    {
                        goto k;
                    }
                }
                test.Add(word);

            }
            return test;

        }
        public static bool CheckList(List<Word> list, Word word)
        {
            if (list.Contains(word)) return false;
            else return true;

        }
    }
}
