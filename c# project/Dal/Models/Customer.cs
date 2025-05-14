using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? PasswordCustomer { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
