using MindWord.Domain.Common;

namespace MindWord.Domain.Entities
{
    public class Word : BaseEntity
    {
        public string Name { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty;
        public string Translate { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string AudioPath { get; set; } = string.Empty;
        public int CorrectCoins { get; set; } = 0;
        public int ErrorCoins { get; set; } = 0;
        public int CategoryId { get; set; }
    }
}
