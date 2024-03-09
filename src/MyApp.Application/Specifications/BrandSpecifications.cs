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
    public static class BrandSpecifications
    {
        public static BaseSpecification<Brand> GetBrandByName(string brandName)
        {
            return new BaseSpecification<Brand>(x => x.Name == brandName);
        }
        public static BaseSpecification<Brand> GetBrandById(int id)
        {
            return new BaseSpecification<Brand>(x => x.Id == id);
        }
        public static BaseSpecification<Brand> GetCategoriesByBrandId(int id)
        {
            return new BaseSpecification<Brand>(x => x.Id == id);
        }
    }
}
