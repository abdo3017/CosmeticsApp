﻿using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyApp.Domain.Entities;

public partial class Gallery : BaseEntity
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public byte[] Image { get; set; } = null!;

    public bool IsCover { get; set; }

    [JsonIgnore]
    public virtual Product Product { get; set; }
}
