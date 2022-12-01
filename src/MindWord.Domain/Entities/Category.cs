using MindWord.Domain.Common;

namespace MindWord.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
