using System;
using System.Collections.Generic;

namespace Dto.dto_classes;

public partial class OrderDto
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public double TotalPayment { get; set; }

    public string Note { get; set; } = null!;

    public bool? Paid { get; set; }

    public virtual CustomerDto? Customer { get; set; }

  
}
