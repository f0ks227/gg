using System;
using System.Collections.Generic;

namespace BD_SQL;

public partial class ChatMessage
{
    public int Id { get; set; }

    public int? ChatId { get; set; }

    public int? SenderId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? SentAt { get; set; }

    public virtual SupportChat? Chat { get; set; }

    public virtual Customer? Sender { get; set; }
}
