using MindWord.Domain.Constants;
using MindWord.Service.Helpers;
using MindWord.Service.Interfaces.Common;

namespace MindWord.Service.Services.Common
{
    public class ImageService : IImageCommon
    {
        private readonly string _imageFolderPath = DbConstants.ACCOUNT_IMAGE_PATH;

       


        public bool DeleteImageAsync(string relativeFilePath)
        {
            if (Directory.Exists(_imageFolderPath))
            {
                if (File.Exists(_imageFolderPath + "/" + relativeFilePath))
                {
                    File.Delete(_imageFolderPath + "/" + relativeFilePath);
                    return true;
                }
            }
            return false;

        }

        public async Task<string> SaveImageAsync(byte[] bytes)
        {
            if (!Directory.Exists(_imageFolderPath))
            {
                Directory.CreateDirectory(_imageFolderPath);
            }
            string path = _imageFolderPath + "/" + ImageHelper.MakeImageName();
            await File.WriteAllBytesAsync(path, bytes);
            return path;
        }

        public string DefaultImage()
        {
            return (_imageFolderPath + "/" + "Default.jpg");
        }

    }
}
