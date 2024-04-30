using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Entities;

public partial class Category : BaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Icon { get; set; }
    public bool? IsSelected { get; set; }

    public int? ParentId { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? ModificationDate { get; set; }

    public byte[]? Image { get; set; } 

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();
}
