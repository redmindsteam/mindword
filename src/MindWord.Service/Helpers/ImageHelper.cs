namespace MindWord.Service.Helpers
{
    public class ImageHelper
    {
        public static string MakeImageName()
        {
            string strpath = Path.GetExtension(".jpg");

            string guid = Guid.NewGuid().ToString();
            return "IMG_" + guid + strpath;
        }
    }
}
