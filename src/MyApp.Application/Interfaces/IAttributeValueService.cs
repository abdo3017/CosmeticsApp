﻿using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IAttributeValueService
    {
        Task<AttributeValueDTO> CreateAttrVal(CreateAttributeValueDTO req);
        void DeleteAttrVal(int id);
        Task<List<AttributeValueDTO>> GetAllAttributeValues();
        Task<List<AttributeValueDTO>> GetAttributeValuesByProductId(int productId);
        Task<List<AttributeValueDTO>> GetAttributeValuesByAttributeId(int attributeId);
        Task UpdateAttrVal(UpdateAttributeValueDTO req);
    }
}
