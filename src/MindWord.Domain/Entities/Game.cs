using MindWord.Domain.Common;

namespace MindWord.Domain.Entities
{
    public class Game : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
