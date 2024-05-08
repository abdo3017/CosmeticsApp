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
        public static BaseSpecification<Category> GetSelectedCategories()
        {
            return new BaseSpecification<Category>(x => x.IsSelected == true);
        }
        public static BaseSpecification<Category> GetAllParentCategories()
        {
            return new BaseSpecification<Category>(x => x.ParentId == null);
        }
        public static BaseSpecification<Category> GetCategoryById(int id)
        {
            return new BaseSpecification<Category>(x => x.Id == id);
        }

        public static BaseSpecification<Category> GetCategoryByNameLike(string name)
        {
            var spec = new BaseSpecification<Category>(p => p.Name.Contains(name));
            spec.ApplyPaging(0, 5);
            return spec;
        }
    }
}
