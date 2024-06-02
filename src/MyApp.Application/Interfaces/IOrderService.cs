using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IOrderService : IBaseOrderService
    {
        Task<PlaceOrderResultDTO> PlaceOrderAsync(OrderDTO DTO);
        Task<List<OrderDTO>> GetOrdersByCustomerId(int customerId);
        
    }
}
