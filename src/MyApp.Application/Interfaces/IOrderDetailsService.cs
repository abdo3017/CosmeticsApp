using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;


namespace MyApp.Application.Interfaces
{
    public interface IOrderDetailsService
    {
        Task<OrderDetail> Create (OrderDetailsDTO orderDetailsDTO , int OrderId , decimal ProductPrice);
    }
}
