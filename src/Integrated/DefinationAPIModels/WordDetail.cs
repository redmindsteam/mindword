﻿namespace Integrated.Models.DefinationAPIModels
{
    public class WordDetail
    {
        public string word { get; set; } = string.Empty;
        public string phonetic { get; set; } = string.Empty;
        public List<Phonetic> phonetics { get; set; }
        public List<Meaning> meanings { get; set; }
    }
}