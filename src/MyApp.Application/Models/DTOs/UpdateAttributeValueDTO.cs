using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class UpdateAttributeValueDTO
    {
        public int Id { get; set; }

        public int AttributeId { get; set; }

        public int ProductId { get; set; }
        public int Qty { get; set; }

        public string Value { get; set; } = null!;
    }
}
