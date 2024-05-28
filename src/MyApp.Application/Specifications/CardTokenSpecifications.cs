using MyApp.Application.Core.Specifications;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Specifications
{
    public static class CardTokenSpecifications
    {
        public static BaseSpecification<CardToken> GetCardTokensByCustomerId(int id)
        {
            return new BaseSpecification<CardToken>(x => x.CustomerId == id);
        }
    }
}
