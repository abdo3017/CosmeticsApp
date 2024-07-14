using Microsoft.EntityFrameworkCore;
using MyApp.Application.Core.Services;
using MyApp.Application.Core.Specifications;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Mappers;
using MyApp.Application.Specifications;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class BaseOrderService : BaseService<Order, int>, IBaseOrderService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        private readonly IAttributeValueService _attributeValueService;
        private readonly IOrderDetailsService _OrderDetailsService;
        private readonly IShipmentCostService _iShipmentCostService;

        public BaseOrderService(IUnitOfWork unitOfWork, IProductService productService, IAttributeValueService attributeValueService, IOrderDetailsService orderDetailsService, IShipmentCostService iShipmentCostService) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
            _attributeValueService = attributeValueService;
            _OrderDetailsService = orderDetailsService;
            _iShipmentCostService = iShipmentCostService;
        }

        public async Task<Order> Create(OrderDTO DTO)
        {
            var SalesOrder = await AddAsync(DTO.MapForCreate());
            return SalesOrder;
        }

        public async Task<OrderDTO?> GetOrderById(int id)
        {
            var specification = OrderSpecifications.GetOrderById(id);

            var order = await _repository.FirstOrDefaultAsync(specification);

            var dtoOrder = order?.Map();

            return dtoOrder;
        }
        public async Task<OrderDTO?> GetOrderWithDetailsById(int id)
        {
            var specification = OrderSpecifications.GetOrderById(id);

            var order = await _repository.FirstOrDefaultAsync(specification);

            var dtoOrder = order?.Map();

            return dtoOrder;
        }
        public async Task<List<OrderDTO>> GetOrdersByCustomerId(BaseSpecification<Order> specification)
        {

            var orders = await _repository.ListAsync(specification);

            var dtoOrders = orders.Select(x => x.Map()).ToList();

            return dtoOrders;
        }

        public async Task<List<OrderDTO>> GetAllOrders(int id)
        {
            var orders = await _repository.GetAllAsync();

            var ordersDto = orders.Select(s => s.Map()).ToList();

            return ordersDto;
        }

        public void Delete(OrderDTO DTO)
        {
            DeleteById(DTO.Id);
        }

        public void Update(OrderDTO DTO)
        {
            Update(DTO.Map());
        }

        public async Task UpdateReturnedQty(OrderDetailsDTO orderDetail)
        {
            await UpdateProductWithReturnedQty(orderDetail);
            await UpdateAttributeValueWithReturnedQty(orderDetail);
        }

        public async Task UpdateProductWithReturnedQty(OrderDetailsDTO orderDetail)
        {
            var product = await _productService.GetProductById(orderDetail.ProductId);
            if (product is productDTO)
            {
                product.Qty += orderDetail.ProductQty;
                _productService.UpdateProduct(product);
            }
        }

        public async Task UpdateAttributeValueWithReturnedQty(OrderDetailsDTO orderDetail)
        {
            if (orderDetail.AttrValueId != null)
            {
                var attributeValue = await _attributeValueService.GetAttributeValuesById((int)orderDetail.AttrValueId);
                if (attributeValue is AttributeValueDTO)
                {
                    attributeValue.Qty += orderDetail.ProductQty;
                    await _attributeValueService.UpdateAttrVal(attributeValue.MapForUpdate());
                }
            }
        }
        public void ConfirmOrder(OrderDTO DTO)
        {
            var order = DTO.Map();
            order.Status = (byte)OrderStatus.Confirmed;
            Update(order);
        }

        public async Task<List<OrderDTO>> GetAllOrdersPageing(int pageNo, int pageSize, int orderType)
        {

            var spec = OrderSpecifications.GetOrderWithpageing(pageNo, pageSize, orderType);
            var orders = await _repository.ListAsync(spec);
            var dtoOrders = orders.Select(x => x.Map()).ToList();
            return dtoOrders;
        }

        public async Task<int> GetOrdersCount(int orderType)
        {
            var spec = OrderSpecifications.GetOrderByType(orderType);
            var orders = await _repository.ListAsync(spec);
            return orders.Count();
        }
    }
}
