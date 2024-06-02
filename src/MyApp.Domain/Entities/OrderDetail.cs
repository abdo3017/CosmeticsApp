using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Entities;

public partial class OrderDetail : BaseEntity
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int Qty { get; set; }

    public decimal TotalPrice { get; set; }

    public int ProductId { get; set; }

    public int? AttrValueId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

 //   public virtual AttributeValue? AttributeValue { get; set; } 
}
