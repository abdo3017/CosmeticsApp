﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttributeValueController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AttributeValueController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var allAttributeValues = await _serviceManager.AttributeValueService.GetAllAttributeValues();
            return Ok(allAttributeValues);
        }

        [HttpGet("GetAttributeValuesByAttributeId")]
        public async Task<IActionResult> GetAttributeValuesByAttributeId(int AttributeId)
        {
            var filteredAttributeValues = await _serviceManager.AttributeValueService.GetAttributeValuesByAttributeId(AttributeId);
            return Ok(filteredAttributeValues);
        }

        [HttpGet("GetAttributeValuesByProductId")]
        public async Task<IActionResult> GetAttributeValuesByProductId(int ProductId)
        {
            var filteredAttributeValues = await _serviceManager.AttributeValueService.GetAttributeValuesByProductId(ProductId);
            return Ok(filteredAttributeValues);
        }

        [HttpGet("GetAttributeValuesById")]
        public async Task<IActionResult> GetAttributeValuesById(int AttrId)
        {
            var filteredAttributeValues = await _serviceManager.AttributeValueService.GetAttributeValuesByIdAsNoTracking(AttrId);
            return Ok(filteredAttributeValues);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateAttributeValueDTO attr)
        {
            try
            {
                var res = await _serviceManager.AttributeValueService.CreateAttrVal(attr);
                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest( new { Msg = ex.Message});
            }

        }

        [HttpPut]
        public IActionResult Update(UpdateAttributeValueDTO attr)
        {
            _serviceManager.AttributeValueService.UpdateAttrVal(attr);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _serviceManager.AttributeValueService.DeleteAttrVal(Id);
            return Ok();
        }
    }

}
