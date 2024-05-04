using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Entities
{
    public class ShipmentCost : BaseEntity
    {
        public int Id { get; set; } 
        public string Area { get; set; }
        public string City { get; set; }
        public decimal Cost { get; set; }

    }
}
