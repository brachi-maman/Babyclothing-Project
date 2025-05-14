using System;
using System.Collections.Generic;

namespace Dto.dto_classes;

public partial class CustomerDto
{
    public int CustomerId { get; set; }

    public string? PasswordCustomer { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

   
}
