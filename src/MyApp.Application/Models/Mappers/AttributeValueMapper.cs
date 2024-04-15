﻿using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.Mappers
{
    public static class AttributeValueMapper
    {

        public static AttributeValueDTO Map ( this AttributeValue attr)
        {
            return new AttributeValueDTO
            {
                AttributeId = attr.AttributeId,
                AttributeName = attr.Attribute.Name,
                ProductId = attr.ProductId,
                Qty = attr.Qty,
                Value = attr.Value
            }; 
        }
        public static AttributeValue Map(this AttributeValueDTO attr)
        {
            return new AttributeValue
            {
                AttributeId = attr.AttributeId,
                Qty = attr.Qty,
                ProductId = attr.ProductId,
                Value = attr.Value
            };
        }
    }
}
