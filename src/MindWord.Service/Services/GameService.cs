using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Domain.Entities;
using MindWord.Service.Attributes;
using System.Data.Entity.Core.Metadata.Edm;

namespace MindWord.Service.Services
{
    public class GameService
    {
        public async Task<List<List<string>>> RandomTestAsync()
        {
            Random random = new Random();
            List<List<string>> test = new List<List<string>>();
            IWordRepository repository = new WordRepository();
            var id = IdentitySingelton.currentId().UserId;
            var ALLWORDS = (await repository.GetAllAsync()).ToList();
            var wordsDB = ALLWORDS.Where(x=>x.UserId == id).ToList();

            var words = Shuffle(wordsDB);
            if (words.Count >= 4)
            {
                for (int i = 0; i < words.Count; i++)
                {
                    List<string> list = new List<string>() { "", "", "", "", "", "" };
                    list[0] = words[i].Name;
                    list[random.Next(1, 4)] = words[i].Translate;
                    list[5] = words[i].Translate;
                    while (list[1] == "" || list[2] == "" || list[3] == "" || list[4] == "")
                    {
                        var res = words[random.Next(0, words.Count)].Translate;
                        for (int l = 1; l < 5; l++)
                        {
                            if (list[l] == "" && !list.Contains(res))
                                list[l] = res;
                        }
                    }
                    test.Add(list);
                }
                return test;
            }
            else return new List<List<string>>();


        }
        public async Task<List<List<string>>> RandomTranslateTestAsync()
        {

            {
                Random random = new Random();
                List<List<string>> test = new List<List<string>>();
                IWordRepository repository = new WordRepository();
                var id = IdentitySingelton.currentId().UserId;
                var ALLWORDS = (await repository.GetAllAsync()).ToList();
                var wordsDB = ALLWORDS.Where(x => x.UserId == id).ToList();

                var words = Shuffle(wordsDB);

                if(words.Count >= 4)
                {
                    for (int i = 0; i < words.Count; i++)
                    {
                        List<string> list = new List<string>() { "", "", "", "", "", "" };
                        list[0] = words[i].Translate;
                        list[random.Next(1, 4)] = words[i].Name;
                        list[5] = words[i].Name;
                        while (list[1] == "" || list[2] == "" || list[3] == "" || list[4] == "")
                        {
                            var res = words[random.Next(0, words.Count)].Name;
                            for (int l = 1; l < 5; l++)
                            {
                                if (list[l] == "" && !list.Contains(res))
                                    list[l] = res;
                            }
                        }
                        test.Add(list);
                    }
                    return test;
                }
                else return new List<List<string>>();

            }
        }
        public static List<Word> Shuffle(List<Word> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Word value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public async Task<List<Word>> RandomTestDescriptionAsync()
        {
            IWordRepository repository = new WordRepository();
            var id = IdentitySingelton.currentId().UserId;
            var ALLWORDS = (await repository.GetAllAsync()).ToList();
            var wordsDb = ALLWORDS.Where(x => x.UserId == id).ToList();
            var words = Shuffle(wordsDb);
            return words;
        }

        public async Task<List<Word>> RandomTestVoiceAsync()
        {
            IWordRepository repository = new WordRepository();
            var id = IdentitySingelton.currentId().UserId;
            var ALLWORDS = (await repository.GetAllAsync()).ToList();
            var wordsDb = ALLWORDS.Where(x => x.UserId == id && (x.AudioPath != null || x.AudioPath != "")).ToList();
            var words = Shuffle(wordsDb);
            return words;
        }
    }
}
