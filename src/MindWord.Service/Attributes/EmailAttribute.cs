using System.Text.RegularExpressions;

namespace MindWord.Service.Attributes
{
    public class EmailAttribute
    {
        public  (bool isSuccessful, string Message) IsValid(string email)
        {
            if (email is null) return (false, "Email can not be null!");

            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            if (regex.Match(email.ToString()!).Success)
                return (true, " ");

            return (false, "Enter correct email!");
        }
    }
}
