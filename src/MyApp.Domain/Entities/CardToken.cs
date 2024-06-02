using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Entities;

public partial class CardToken:BaseEntity
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Token { get; set; } = null!;
    public int? LastDigit { get; set; } 
}
