namespace MindWord.Service.Interfaces.Common
{
    public interface IImageCommon

    {
       
        Task<string> SaveImageAsync(byte[] bytes);
        bool DeleteImageAsync(string relativeFilePath);
    }
}
