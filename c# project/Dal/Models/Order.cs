using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Order
{
    public int OrdersId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public double TotalPayment { get; set; }

    public string? Note { get; set; }

    public bool? Paid { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrdersDetail> OrdersDetails { get; set; } = new List<OrdersDetail>();
}
