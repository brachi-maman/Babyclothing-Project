using System;
using System.Collections.Generic;
//using Models;
using Microsoft.AspNetCore.Http;

namespace Dto.dto_classes;

public partial class ProductDto
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ? CategoryName { get; set; } 

    public int? CategoryId { get; set; }

    public int? CompanyId { get; set; }

    public string? DescriptionProducts { get; set; }

    public double Price { get; set; }

    public string? ImageUrl { get; set; }

    public int StockQuantity { get; set; }

    public DateTime? LastUpdated { get; set; }

    public string? Season { get; set; }

    public string? Size { get; set; }

    public string? Gender { get; set; }

    public string? CName {  get; set; }
    public IFormFile? ImageFile { get; set; }  // לקבלת קובץ מהלקוח

    public string? CompanyName { get; set; }

    //public virtual Category ? category { get; set; }
    
    //public virtual CompanyDto? Company { get; set; }

    //public virtual ICollection<OrdersDetailDto> OrdersDetails { get; } = new List<OrdersDetailDto>();
}
