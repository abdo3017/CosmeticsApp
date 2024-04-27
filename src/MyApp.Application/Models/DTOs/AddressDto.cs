using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class AddressDto
    {
        public int CustomerId { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }

    }
}
