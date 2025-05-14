using System;
using System.Collections.Generic;

namespace Dto.dto_classes;

public partial class OrdersDetailDto
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    //public virtual OrderDto? Order { get; set; }

    //public virtual ProductDto? Product { get; set; }
}
