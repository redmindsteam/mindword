using MindWord.Domain.Common;

namespace MindWord.Domain;

public class Auditable : BaseEntity
{
    public DateTime CreatedAt { get; set; }
}
