using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrated.Models.DefinationAPIModels
{
    public class Meaning
    {
        public string partOfSpeech { get; set; } = string.Empty;
        public List<Defination> definitions { get; set; }
    }
}
