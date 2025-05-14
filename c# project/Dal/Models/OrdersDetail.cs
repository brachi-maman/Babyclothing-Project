using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class OrdersDetail
{
    public int OrdersDetailId { get; set; }

    public int? OrdersId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Order? Orders { get; set; }

    public virtual Product? Product { get; set; }
}
