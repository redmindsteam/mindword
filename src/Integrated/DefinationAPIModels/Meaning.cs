namespace Integrated.Models.DefinationAPIModels
{
    public class Meaning
    {
        public string partOfSpeech { get; set; } = string.Empty;
        public List<Defination> definitions { get; set; }
    }
}