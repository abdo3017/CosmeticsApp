using MyApp.Application.Core.Specifications;
using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
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
        public static BaseSpecification<Product> GetProductsByBrandId(int id, int pageNo, int pageSize)
        {
            var spec = new BaseSpecification<Product>(Product => Product.BrandId == id);
            spec.ApplyPaging((pageNo - 1) * pageSize, pageSize);
            return spec;
        }
        public static BaseSpecification<Product> GetProductsByCategoryId(int id, int pageNo, int pageSize)
        {
            var spec = new BaseSpecification<Product>(Product => Product.CategoryId == id);
            spec.ApplyPaging((pageNo - 1) * pageSize, pageSize);
            return spec;
        }
        public static BaseSpecification<Product> GetProductWithPaging(int pageNo, int pageSize)
        {
            var spec = new BaseSpecification<Product>();
            spec.ApplyPaging((pageNo - 1) * pageSize, pageSize);
            return spec;
        }

        public static BaseSpecification<Product> GetProductByIdWithImgs(int id)
        {
            var spec = new BaseSpecification<Product>(Product => Product.Id == id);
            spec.AddInclude(p => p.Imgs);
            return spec;
        }

        public static BaseSpecification<Product> GetProductWithRateGt4_5(int pageNo, int pageSize)
        {
            var spec = new BaseSpecification<Product>(BestProductExepression());
            spec.ApplyPaging((pageNo - 1) * pageSize, pageSize);
            return spec;
        }
        static Expression<Func<Product, bool>> RecentProductExepression()
        {
            Expression<Func<Product, bool>> criteria = Product => Product.CreationDate.AddDays(7) >= DateTime.Today || Product.Tag == (int)TagType.Recent;
            return criteria;
        }
        static Expression<Func<Product, bool>> MostPopularProductExepression()
        {
            Expression<Func<Product, bool>> criteria = Product => Product.Tag == (int)TagType.MostPopular;
            return criteria;
        }
        static Expression<Func<Product, bool>> BestProductExepression()
        {
            Expression<Func<Product, bool>> criteria = Product => Product.RateValue >= 4.5m || Product.Tag == (int)TagType.Best;
            return criteria;
        }
        public static BaseSpecification<Product> GetRecentProduct(int pageNo, int pageSize)
        {
            var spec = new BaseSpecification<Product>(RecentProductExepression());
            spec.ApplyPaging((pageNo - 1) * pageSize, pageSize);
            return spec;
        }

        public static BaseSpecification<Product> GetMostPopularProduct(int pageNo, int pageSize)
        {
            var spec = new BaseSpecification<Product>(MostPopularProductExepression());
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
            if (filters.Discount != null)
            {

                var property = Expression.Property(parameter, "DiscountPercentage");

                var UptoDiscountExprestion = Expression.Lambda<Func<Product, bool>>(
                    Expression.And(
                        Expression.GreaterThan(property, Expression.Constant(0)),
                        Expression.Equal(property, Expression.Constant(filters.Discount))
                    ), parameter);
                filterExpression = filterExpression != null ? Expression.AndAlso(filterExpression, UptoDiscountExprestion.Body) : UptoDiscountExprestion.Body;
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
                var property = Expression.Property(parameter, "Tag");
                var propertyValue = Expression.Constant(filters.Tags);
                var containsMethod = typeof(List<int>).GetMethod("Contains");
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

            var tagsExep = TagsExepression(filters);

            if(filterExpression is not null)
                expression = Expression.Lambda<Func<Product, bool>>(filterExpression, parameter);

            if (expression is not null && tagsExep is not null)
                expression = expression.And(tagsExep);
            else if(tagsExep is not null)
                expression = tagsExep;

            var spec = new BaseSpecification<Product>(criteria: expression);
            spec.ApplyPaging((pageNo - 1) * pageSize, pageSize);

            return spec;
        }
        static Expression<Func<Product, bool>> TagsExepression(ProductFilter filters)
        {
            Expression<Func<Product, bool>> expression = null;
            var parameter = Expression.Parameter(typeof(Product), "Product");

            if (filters.Recent)
            {
                expression = RecentProductExepression();
            }
            if (filters.MostPopular)
            {
                var mostPopularExep = MostPopularProductExepression();
                expression = expression != null? mostPopularExep.Or(expression): mostPopularExep;
            }
            if (filters.Best)
            {
                var bestSpec = BestProductExepression();
                expression = expression != null ? bestSpec.Or(expression) : bestSpec;
            }
            return expression;
        }
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                      Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
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
