using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Entities;

public partial class Customer_Address : BaseEntity
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Area { get; set; } = null!;
    public string? Street { get; set; }

}
