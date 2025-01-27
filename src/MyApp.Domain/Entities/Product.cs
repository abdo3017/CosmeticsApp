﻿using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Entities;

public partial class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? NameAr { get; set; } 
    public int CategoryId { get; set; }

    public string? Description { get; set; }
    public string? DescriptionAr { get; set; }

    public int BrandId { get; set; }

    public decimal Price { get; set; }

    public int Qty { get; set; }

    public decimal RateValue { get; set; }

    public int TotalRate { get; set; }

    public int DiscountPercentage { get; set; }

    public int Tag { get; set; } = -1;

    public DateTime CreationDate { get; set; }

    public DateTime? ModificationDate { get; set; }

    public virtual ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();

    public virtual ICollection<Gallery> Imgs { get; set; } = new List<Gallery>();

    public virtual Brand Brand { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
