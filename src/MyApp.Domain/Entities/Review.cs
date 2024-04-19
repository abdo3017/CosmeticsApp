using MyApp.Domain.Core.Models;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Models;

public partial class Review : BaseEntity
{
    public int Id { get; set; }
    public string Comment { get; set; } = null!;
    public decimal Rate { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int CustomerId { get; set; }
    public virtual User User { get; set; }

    public int ProductId { get; set; }
}
