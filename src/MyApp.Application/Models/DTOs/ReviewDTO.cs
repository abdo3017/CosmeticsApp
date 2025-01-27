﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Comment { get; set; } = null!;
        public decimal Rate { get; set; }
        public int ProductId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
    }
}
