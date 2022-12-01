namespace MindWord.Service.Interfaces.Security
{
    public interface IPasswordHasher
    {
        public (string passwordHash, string salt) Hash(string password);

        public bool Verify(string password, string salt, string hash);
    }
}
