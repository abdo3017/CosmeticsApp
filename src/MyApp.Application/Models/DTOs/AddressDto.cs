using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class AddressDto
    {
        public int CustomerId { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        [JsonIgnore]
        public string? CityAr { get; set; }
        [JsonIgnore]
        public string? AreaAr { get; set; }
        public string Street { get; set; }

    }
}
