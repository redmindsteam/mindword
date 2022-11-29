using Integrated.Models.DefinationAPIModels;
using MindWord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrated.Interfaces
{
    public interface IDefinationAPIService
    {
        public Task<(bool,byte[]?)> GetVoiceAsync(List<Phonetic> phonetics);
        public Task<List<WordDetail>> GetWordDeteilAsync(string word);
        public Task<Word> 
    }
}
