using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class CreateReviewDTO
    {
        public string Comment { get; set; } = null!;
        public decimal Rate { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
