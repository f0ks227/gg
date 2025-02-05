using System;
using System.Collections.Generic;

namespace FastCatXyi;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
