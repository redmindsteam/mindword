using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.Service.Helpers
{
    public class ImageHelper
    {
        public static string MakeImageName(string fileName)
        {
            string strpath = Path.GetExtension(fileName);

            string guid = Guid.NewGuid().ToString();
            return "IMG_" + guid + strpath;
        }
    }
}
