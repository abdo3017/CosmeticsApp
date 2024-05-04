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
        Task<OrderDTO?> GetOrderById(int id);
        Task<OrderDTO?> GetOrderWithDetailsById(int id);
        Task<List<OrderDTO>> GetAllOrders(int id);
        void Delete(OrderDTO DTO);
        void Update(OrderDTO DTO);
        Task<Order> Create(OrderDTO DTO);
        Task UpdateProductWithReturnedQty(OrderDetailsDTO orderDetail);
        Task UpdateAttributeValueWithReturnedQty(OrderDetailsDTO orderDetail);
        Task UpdateReturnedQty(OrderDetailsDTO orderDetail);
        void ConfirmOrder(OrderDTO DTO);
    }
}
