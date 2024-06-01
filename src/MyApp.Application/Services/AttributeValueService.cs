using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Mappers;
using MyApp.Application.Specifications;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;
using MyApp.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class AttributeValueService : BaseService<AttributeValue, int>, IAttributeValueService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttributeValueService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AttributeValueDTO>> GetAllAttributeValues()
        {
            var attributeValues = await _repository.GetAllAsync();

            var attributeValuesDto = attributeValues.Select(s => s.Map()).ToList();

            return attributeValuesDto;
        }

        public async Task<List<AttributeValueDTO>> GetAttributeValuesByAttributeId(int attributeId)
        {
            var spec = AttributeValueSpecifications.GetAttributeValuesByAttributeId(attributeId);

            var attributeValues = await _repository.ListAsync(spec);

            var attributeValuesDto = attributeValues.Select(s => s.Map()).ToList();

            return attributeValuesDto;
        }

        public async Task<List<AttributeValueDTO>> GetAttributeValuesByProductId(int productId)
        {
            var spec = AttributeValueSpecifications.GetAttributeValuesByProductId(productId);

            var attributeValues = await _repository.ListAsync(spec);

            var attributeValuesDto = attributeValues.Select(s => s.Map()).ToList();

            return attributeValuesDto;
        }

        public async Task<AttributeValueDTO> CreateAttrVal(CreateAttributeValueDTO req)
        {
            var attr = req.Map();
            await ValidateQty(attr);
            var AddeAtrrVall = await AddAsync(attr);
            return AddeAtrrVall.Map();
        }


        public async Task UpdateAttrVal(UpdateAttributeValueDTO req)
        {
            var attr = req.Map();
            await ValidateQty(attr);
            Update(attr);
        }
        public async Task UpdateAttrValWithoutSaving(UpdateAttributeValueDTO req)
        {
            var attr = req.Map();
            //await ValidateQty(attr);
            UpdateWithoutSave(attr);
        }

        public void DeleteAttrVal(int id)
        {
            DeleteById(id);
        }

        private async Task ValidateQty(AttributeValue attr)
        {
            var spec = AttributeValueSpecifications.GetAttributeValuesByProductId(attr.ProductId);

            var productRepo = _unitOfWork.Repository<Product, int>();
            var products = await productRepo.GetAllAsync();
            var product = await productRepo.GetByIdAsync(attr.ProductId);

            var attrList = await _repository.ListAsync(spec);
            var totalQty = attrList.Sum(x => x.Qty);
            if (totalQty + attr.Qty > product?.Qty)
            {
                throw new Exception("the quantity exceed product's quantity limit");
            }
        }

        public async Task<AttributeValueDTO?> GetAttributeValuesById(int id)
        {
            var res = await GetByIdAsync(id);
            return res?.Map();
        }
        public async Task<AttributeValueDTO?> GetAttributeValuesByIdAsNoTracking(int id)
        {
            var spec = AttributeValueSpecifications.GetAttributeValuesById(id);
            var res = await _repository.FirstOrDefaultNoTrackingAsync(spec);
            return res?.Map();
        }
    }
}
