using MyApp.Application.Models.DTOs;
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
        Task<AttributeValue> CreateAttrVal(AttributeValueDTO req);
        void DeleteAttrVal(AttributeValueDTO req);
        void UpdateAttrVal(AttributeValueDTO req);
    }
}
