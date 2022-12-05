namespace MindWord.Service.Attributes
{
    public class IdentitySingelton
    {
        public int UserId { get; set; }
        public int DUI_Id { get; set; }

        private static IdentitySingelton _instance;
        private static IdentitySingelton _updateid;
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
        public static void SaveUpdateId(int id)
        {
            _updateid = new IdentitySingelton();
            _updateid.DUI_Id = id;
        }
        public static IdentitySingelton UpdateId()
        {
            return _updateid;
        }
    }
}
