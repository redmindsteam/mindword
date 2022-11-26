using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.Service.Attributes
{
    public class StrongPasswordAttribute
    {
        public (bool isSuccessful, string Message) IsValid(string password)
        {

            if (password is null) return (false, "Password can not be null!");
            else
            {
                if (password.Length < 8)
                    return (false,"Password must be at least 8 characters!");
                else if (password.Length > 50)
                    return (false,"Password must be less than 50 characters!");
                var result = IsStrong(password);

                if (result.IsValid is false) return (false,result.Message);
                return (true, result.Message);
            }
        }


        public (bool IsValid, string Message) IsStrong(string password)
        {
            bool isDigit = password.Any(x => char.IsDigit(x));
            bool isLower = password.Any(x => char.IsLower(x));
            bool isUpper = password.Any(x => char.IsUpper(x));
            if (!isLower)
                return (IsValid: false, Message: "Password must be at least one lower letter!");
            if (!isUpper)
                return (IsValid: false, Message: "Password must be at least one upper letter!");
            if (!isDigit)
                return (IsValid: false, Message: "Password must be at least one digit!");

            return (IsValid: true, Message: "Password is strong");
        }
    }
}
