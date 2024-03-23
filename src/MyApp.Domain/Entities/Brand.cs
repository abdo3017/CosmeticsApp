using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Entities;

public partial class Brand : BaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public byte[] Image { get; set; } = null!;

    public DateOnly? CreationDate { get; set; }

    public DateOnly? ModificationDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
