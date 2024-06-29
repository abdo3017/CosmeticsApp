using MyApp.Application.Core.Specifications;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Specifications
{
    public static class GalarySpecifications
    {
        public static BaseSpecification<Gallery> GetProductsById(int productID  , int GallaryId)
        {
            var spec = new BaseSpecification<Gallery>(g => g.Id == GallaryId && g.ProductId == productID);
            return spec;
        }
    }
}
