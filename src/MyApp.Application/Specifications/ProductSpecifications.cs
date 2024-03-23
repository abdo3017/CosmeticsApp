using MyApp.Application.Core.Specifications;
using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Specifications
{
    public static class ProductSpecifications
    {
        public static BaseSpecification<Product> GetProductWithImgs(int pageNo , int pageSize)
        {
            var spec = new BaseSpecification<Product>();
            spec.ApplyPaging((pageNo-1)*pageSize, pageSize);
           // spec.AddInclude(p => p.Imgs);
            return spec;
        }

        public static BaseSpecification<Product> GetProductByIdWithImgs(int id)
        {
            var spec = new BaseSpecification<Product>(x => x.Id == id);
            spec.AddInclude(p => p.Imgs);
            return spec;
        }

        public static BaseSpecification<Product> GetProductByFilters(ProductFilter filters)
        {

            Expression<Func<Product, bool>> expression = null ;
            Expression filterExpression = null;
             var parameter = Expression.Parameter(typeof(Product), "Product");

            if (filters.CategoryIds != null && filters.CategoryIds.Count > 0)
            {
                var property = Expression.Property(parameter, "CategoryId");
                var propertyValue = Expression.Constant(filters.CategoryIds);
                var containsMethod = typeof(List<int>).GetMethod("Contains");
                var containsCall = Expression.Call(propertyValue, containsMethod, property);
                filterExpression = containsCall;
            }
            if (filters.BrandIds != null && filters.BrandIds.Count > 0)
            {
                var property = Expression.Property(parameter, "BrandId");
                var propertyValue = Expression.Constant(filters.BrandIds);
                var containsMethod = typeof(List<int>).GetMethod("Contains");
                var containsCall = Expression.Call(propertyValue, containsMethod, property);
                filterExpression = filterExpression != null ? Expression.AndAlso(filterExpression, containsCall) : containsCall;
            }
            if (filters.Tags != null && filters.Tags.Count > 0)
            {
                var property = Expression.Property(parameter, "TagName");
                var propertyValue = Expression.Constant(filters.Tags);
                var containsMethod = typeof(List<string>).GetMethod("Contains");
                var containsCall = Expression.Call(propertyValue, containsMethod, property);
                filterExpression = filterExpression != null ? Expression.AndAlso(filterExpression, containsCall) : containsCall;
            }
            if (filters.PriceRange != null && filters.PriceRange.Count > 0)
            {
               
                var property = Expression.Property(parameter, "Price");

                var isBetweenExprestion = Expression.Lambda<Func<Product, bool>>(
                    Expression.And(
                        Expression.GreaterThanOrEqual(property, Expression.Constant(filters.PriceRange[0])),
                        Expression.LessThanOrEqual(property, Expression.Constant(filters.PriceRange[1]))
                    ),
                    parameter);
                filterExpression = filterExpression != null ? Expression.AndAlso(filterExpression, isBetweenExprestion.Body) : isBetweenExprestion.Body;
            }


            expression = Expression.Lambda<Func<Product, bool>>(filterExpression, parameter);
            var spec = new BaseSpecification<Product>(criteria: expression); 

            return spec;
        }

        static Expression ConstractContainsExpression(string Param , List<int> list ,Type listType , Type entityType )
        {
            var parameter = Expression.Parameter(entityType, "Product");
            var property = Expression.Property(parameter, Param);
            var propertyValue = Expression.Constant(list);
            var containsMethod = listType.GetMethod("Contains");
            var containsCall = Expression.Call(propertyValue, containsMethod, property);
            return  containsCall;
        }
    }
}
