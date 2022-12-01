namespace MindWord.Service.Attributes
{
    public class IdentitySingelton
    {
        public int UserId { get; set; }

        private static IdentitySingelton _instance;

        private IdentitySingelton()
        {

        }
        public static void SaveId(int id)
        {
            if (_instance == null)
            {
                _instance = new IdentitySingelton();
                _instance.UserId = id;
            }
        }
        public static IdentitySingelton currentId()
        {
            return _instance;
        }
    }
}
