using MindWord.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.Service.ViewModel
{
    public class VoicetestResultViewModel:BaseEntity
    {
        public string AudioPath { get; set; } = string.Empty;
        public string Translate { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;      
    }
}
