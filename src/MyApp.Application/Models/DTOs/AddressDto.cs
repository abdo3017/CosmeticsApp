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
        public int? Id { get; set; }
        public int CustomerId { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string? CityAr { get; set; }
        [JsonIgnore]
        public string? AreaAr { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

    }
}
