namespace MindWord.Domain.Entities
{
    public class User : Auditable
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public string Salt { get; set; } = string.Empty;

        public string AccountImagePath { get; set; } = string.Empty;

    }
}
