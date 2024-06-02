using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyApp.Domain.Entities;

public partial class AttributeValue : BaseEntity
{
    public int AttributeId { get; set; }

    public int ProductId { get; set; }
    public int Qty { get; set; }

    public string Value { get; set; } = null!;

    [JsonIgnore]
    public virtual Attribute Attribute { get; set; } = null!;

    [JsonIgnore]
    public virtual Product Product { get; set; } = null!;


}
