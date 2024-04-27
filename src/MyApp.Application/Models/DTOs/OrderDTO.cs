﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class OrderDTO
    {
        public int CustomerId { get; set; } 
        public int AddressId { get; set; }

        public List<OrderDetailsDTO> Items { get; set;}

    }
}