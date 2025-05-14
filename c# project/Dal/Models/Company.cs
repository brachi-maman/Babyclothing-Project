using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
