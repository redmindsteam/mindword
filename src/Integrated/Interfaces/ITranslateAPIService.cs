namespace Integrated.Interfaces
{
    public interface ITranslateAPIService
    {
        Task<(bool isSuccessful, string TranslatedWord)> GetTranslatedWordAsync(string to, string from, string word);
    }
}
