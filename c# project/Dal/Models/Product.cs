using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? CategoryId { get; set; }

    public int? CompanyId { get; set; }

    public string? DescriptionProduct { get; set; }

    public double Price { get; set; }

    public string? ImageUrl { get; set; }

    public int StockQuantity { get; set; }

    public DateTime? LastUpdated { get; set; }

    public string? Season { get; set; }

    public string? Size { get; set; }

    public string? Gender { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<OrdersDetail> OrdersDetails { get; set; } = new List<OrdersDetail>();
}
