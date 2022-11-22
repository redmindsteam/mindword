using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.Domain.Entities.Users
{
    public class User : Auditable
    {
        public string Name { get; set; } = String.Empty;
    }
}
