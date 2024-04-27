using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Mappers;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class OrderDetailsService : BaseService<OrderDetail, int> , IOrderDetailsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderDetail> Create(OrderDetailsDTO orderDetailsDTO, int OrderId, decimal ProductPrice)
        {
            var orderDetail = orderDetailsDTO.Map(OrderId , ProductPrice); 
            var res = await AddAsync(orderDetail);
            return res;
        }
    }
}
