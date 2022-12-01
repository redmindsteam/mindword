using Integrated.Models.DefinationAPIModels;
using MindWord.Domain.Entities;

namespace Integrated.Interfaces
{
    public interface IDefinationAPIService
    {
        public Task<(bool successful, byte[]? voice)> GetVoiceAsync(List<Phonetic> phonetics);
        public Task<WordDetail?> GetWordDeteilAsync(string word);
        public Task<(bool successful, Word word)> GetWordAsync(string word);
    }
}