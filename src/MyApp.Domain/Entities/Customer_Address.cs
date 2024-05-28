using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Entities;

public partial class Customer_Address : BaseEntity
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Country { get; set; } = null!;
    public string CountryAr { get; set; }

    public string City { get; set; } = null!;
    public string CityAr { get; set; }

    public string PostalCode { get; set; } = null!;

    public string Area { get; set; } = null!;
    public string AreaAr { get; set; }
    public string? Street { get; set; }

}
