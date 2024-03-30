using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Models;

public partial class Review:BaseEntity
{
    public int Id { get; set; }

    public string Comment { get; set; } = null!;

    public decimal Rate { get; set; }

    public int CustomerId { get; set; }
    public int ProductId { get; set; }
}
