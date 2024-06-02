using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class CardTokenDTO
    {
        public int CustomerId { get; set; }
        public string Token { get; set; } = null!;
        public int? LastDigit { get; set; }
    }
}
