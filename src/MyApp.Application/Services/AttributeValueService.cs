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
    public  class AttributeValueService : BaseService<AttributeValue , int>, IAttributeValueService
    {
        public AttributeValueService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<AttributeValue> CreateAttrVal(AttributeValueDTO req)
        {
            var attr = req.Map(); 
            var AddeAtrrVall = await AddAsync(attr);
            return AddeAtrrVall;
        }

        public void DeleteAttrVal(AttributeValueDTO req)
        {
            var attr = req.Map();
            Delete(attr);
        }
        public void UpdateAttrVal(AttributeValueDTO req)
        {
            var attr = req.Map();
            Update(attr);
        }

    }
}
