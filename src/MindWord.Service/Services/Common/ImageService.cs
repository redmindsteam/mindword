using MindWord.Domain.Constants;
using MindWord.Service.Helpers;
using MindWord.Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.Service.Services.Common
{
    public class ImageService : IImageCommon
    {
        private readonly string _imageFolderPath = DbConstants.AccountImagePath;

        public string ImageFolderName => throw new NotImplementedException();


        public bool DeleteImageAsync(string relativeFilePath)
        {
            if (Directory.Exists(_imageFolderPath))
            {
               if (File.Exists(_imageFolderPath+"/"+relativeFilePath))
                {
                    File.Delete(_imageFolderPath+"/"+relativeFilePath);
                    return true;
                }
            }
            return false;

        }

        public async Task SaveImageAsync(byte[] bytes)
        {
            if (!Directory.Exists(_imageFolderPath))
            {
                Directory.CreateDirectory(_imageFolderPath);    
            }
           await File.WriteAllBytesAsync(_imageFolderPath+"/"+ ImageHelper.MakeImageName(), bytes);
        }

        public string DefaultImage()
        {
            return _imageFolderPath + "/" + "Default.jpg";
        }

    }
}
