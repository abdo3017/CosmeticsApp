﻿using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.DTOs;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OrderController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("PlaceSalesOrder")]
        public async Task<IActionResult> PlaceSalesOrder([FromBody] OrderDTO data)
        {
            var  res = await _serviceManager.SalesOrderService.PlaceOrderAsync(data);
            return Ok(res);
        }
        [HttpGet("GetSalesOrdersByCustomerId")]
        public async Task<IActionResult> GetSalesOrdersByCustomerId(int Id)
        {
            var res = await _serviceManager.SalesOrderService.GetOrdersByCustomerId(Id);
            return Ok(res);
        }
        [HttpPost("PlaceReturnOrder")]
        public async Task<IActionResult> PlaceReturnOrder([FromBody] OrderDTO data)
        {
            var res = await _serviceManager.ReturnOrderService.PlaceOrderAsync(data);
            return Ok(res);
        }
        [HttpPost("CancelOrder")]
        public async Task<IActionResult> CancelOrder(int id)
        {
             await _serviceManager.SalesOrderService.CancelOrder(id);
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int  pageNo , int pageSize)
        {
            var res = await _serviceManager.SalesOrderService.GetAllOrdersPageing(pageNo, pageSize , 0 );
            return Ok(res);
        }
        [HttpGet("GetOrderById")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var res = await _serviceManager.BaseOrderService.GetOrderById(id);
            return Ok(res);
        }

        [HttpGet("GetSalesOrderCount")]
        public async Task<IActionResult> GetSalesOrderCount()
        {
            var res = await _serviceManager.SalesOrderService.GetOrdersCount(0);
            return Ok(res);
        }
    }
}
