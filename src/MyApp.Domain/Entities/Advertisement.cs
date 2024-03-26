using System;
using System.Collections.Generic;

namespace MyApp.Infrastructure.Models;

public partial class Advertisement
{
    public int Id { get; set; }

    public byte[]? Img { get; set; }

    public int? TagName { get; set; }

    public int? BrandId { get; set; }

    public int? CategoryId { get; set; }

    public int? Discount { get; set; }
}
