﻿using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
     public interface IBaseOrderService
    {
        Task<Order> Create(OrderDTO DTO);
    }
}
