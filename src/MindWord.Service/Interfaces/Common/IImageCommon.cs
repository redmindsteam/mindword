namespace MindWord.Service.Interfaces.Common
{
    public interface IImageCommon

    {
        public string ImageFolderName { get; }
        Task SaveImageAsync(byte[] bytes);
        bool DeleteImageAsync(string relativeFilePath);
    }
}
