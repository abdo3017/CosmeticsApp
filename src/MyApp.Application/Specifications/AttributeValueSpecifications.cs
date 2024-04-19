using MyApp.Application.Core.Specifications;
using MyApp.Application.Models.DTOs;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Specifications
{
    public static class AttributeValueSpecifications
    {
        public static BaseSpecification<AttributeValue> GetAttributeValuesByProductId(int productId)
        {
            return new BaseSpecification<AttributeValue>(x => x.ProductId == productId);
        }

        internal static ISpecification<AttributeValue> GetAttributeValuesByAttributeId(int attributeId)
        {
            return new BaseSpecification<AttributeValue>(x => x.AttributeId == attributeId);
        }
    }
}
