using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Entities;

public partial class Order : BaseEntity
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public byte Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public decimal TotalPrice { get; set; }

    public byte Type { get; set; }

    public int AddressId { get; set; }

    public byte DeliveryType { get; set; }
    public DateTime? DeliveredAt { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
