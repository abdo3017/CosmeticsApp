using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Entities;

public partial class Cart : BaseEntity
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();
}
