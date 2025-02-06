using System;
using System.Collections.Generic;

namespace FastCatXyi;

public partial class Customer
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string PasswordHash { get; set; } = null!;

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

    public virtual ICollection<SupportChat> SupportChats { get; set; } = new List<SupportChat>();
}
