﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class ShipmentCostDTO
    {
        public int Id { get; set; }
        public string Area { get; set; } = null!;
        public string City { get; set; } = null!;
        public decimal Cost { get; set; }
        [JsonIgnore]
        public string? AreaAr { get; set; }
        [JsonIgnore]
        public string? CityAr { get; set; }
    }
}
