using System;
using System.Collections.Generic;

namespace FastCatXyi.ModelsNew;

public partial class SupportChat
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual Customer? Customer { get; set; }
}
