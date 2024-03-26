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
        public static BaseSpecification<Product> GetProductsByBrandId(int id)
        {
            return new BaseSpecification<Product>(x => x.BrandId == id);
        }
        public static BaseSpecification<Product> GetProductsByCategoryId(int id)
        {
            return new BaseSpecification<Product>(x => x.CategoryId == id);
        }
        public static BaseSpecification<Product> GetProductWithPaging(int pageNo, int pageSize)
        {
            var spec = new BaseSpecification<Product>();
            spec.ApplyPaging((pageNo - 1) * pageSize, pageSize);
            return spec;
        }

        public static BaseSpecification<Product> GetProductByIdWithImgs(int id)
        {
            var spec = new BaseSpecification<Product>(x => x.Id == id);
            spec.AddInclude(p => p.Imgs);
            return spec;
        }

        public static BaseSpecification<Product> GetProductWithRateGt4_5(int pageNo, int pageSize)
        {
            var spec = new BaseSpecification<Product>(x => x.RateValue >= 4.5m);
            spec.ApplyPaging((pageNo - 1) * pageSize, pageSize);
            return spec;
        }

        public static BaseSpecification<Product> GetRecentProduct(int pageNo, int pageSize)
        {
            var spec = new BaseSpecification<Product>(x => Enumerable.Range(0, 8).Any(offset => (DateTime.Today.AddDays(offset) - x.CreationDate.ToDateTime(TimeOnly.MinValue)).Days == 0));
            spec.ApplyPaging((pageNo - 1) * pageSize, pageSize);
            return spec;
        }

        public static BaseSpecification<Product> GetProductByFilters(ProductFilter filters, int pageNo, int pageSize)
        {
            Expression<Func<Product, bool>> expression = null;
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
            if (filters.MinPrice != null && filters.MaxPrice is not null)
            {

                var property = Expression.Property(parameter, "Price");

                var isBetweenExprestion = Expression.Lambda<Func<Product, bool>>(
                    Expression.And(
                        Expression.GreaterThanOrEqual(property, Expression.Constant(filters.MinPrice)),
                        Expression.LessThanOrEqual(property, Expression.Constant(filters.MaxPrice))
                    ),
                    parameter);
                filterExpression = filterExpression != null ? Expression.AndAlso(filterExpression, isBetweenExprestion.Body) : isBetweenExprestion.Body;
            }
            if (filters.UptoDiscount != null)
            {

                var property = Expression.Property(parameter, "DiscountPercentage");

                var UptoDiscountExprestion = Expression.Lambda<Func<Product, bool>>(
                        Expression.LessThanOrEqual(property, Expression.Constant(filters.UptoDiscount)),parameter);
                filterExpression = filterExpression != null ? Expression.AndAlso(filterExpression, UptoDiscountExprestion.Body) : UptoDiscountExprestion.Body;

            }

            expression = Expression.Lambda<Func<Product, bool>>(filterExpression, parameter);
            var spec = new BaseSpecification<Product>(criteria: expression);
            spec.ApplyPaging((pageNo - 1) * pageSize, pageSize);

            return spec;
        }

        static Expression ConstructContainsExpression(string Param, List<int> list, Type listType, Type entityType)
        {
            var parameter = Expression.Parameter(entityType, "Product");
            var property = Expression.Property(parameter, Param);
            var propertyValue = Expression.Constant(list);
            var containsMethod = listType.GetMethod("Contains");
            var containsCall = Expression.Call(propertyValue, containsMethod, property);
            return containsCall;
        }

      
    }
}
