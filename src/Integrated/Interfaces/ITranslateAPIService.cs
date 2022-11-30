using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrated.Interfaces
{
    public interface ITranslateAPIService
    {
        Task<(bool isSuccessful, string TranslatedWord)> GetTranslatedWordAsync(string to,string from, string word);
    }
}
