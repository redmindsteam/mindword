using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.Service.Interfaces.Common
{
    public interface IImageCommon

    {
        public string ImageFolderName { get; }
        Task SaveImageAsync(byte[] bytes, string imageName);
        bool DeleteImageAsync(string relativeFilePath);
    }
}
