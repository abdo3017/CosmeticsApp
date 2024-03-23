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
    public static class CategorySpecifications
    {
        public static BaseSpecification<Category> GetCategoryByName(string catName)
        {
            return new BaseSpecification<Category>(x => x.Name == catName);
        }
        public static BaseSpecification<Category> GetCategoryById(int id)
        {
            return new BaseSpecification<Category>(x => x.Id == id);
        }
    }
}
