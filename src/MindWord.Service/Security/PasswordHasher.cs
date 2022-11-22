using MindWord.Service.Interfaces.Security;

namespace MindWord.Service.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private const string _key = "";
        public (string passwordHash, string salt) Hash(string password)
        {
            string salt = GenerateSalt();
            string strongpassword = _key + salt + password;
            string hash = BCrypt.Net.BCrypt.HashPassword(strongpassword);
            return (passwordHash: hash,
                    salt: salt);
        }

        public bool Verify(string password, string salt, string hash)
        {
            string strongpassword = _key + salt + password;
            string newhash = BCrypt.Net.BCrypt.HashPassword(strongpassword);
            return hash == newhash;
        }

        private string GenerateSalt()
        {
            string salt = Guid.NewGuid().ToString();
            return salt;
        }
    }
}
