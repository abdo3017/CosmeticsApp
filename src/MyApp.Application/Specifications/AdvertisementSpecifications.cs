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
    public static class AdvertisementSpecifications
    {
        public static BaseSpecification<Advertisement> GetAdvertisementById(int id)
        {
            return new BaseSpecification<Advertisement>(x => x.Id == id);
        }
        public static BaseSpecification<Advertisement> GetAdvertisementById(int? id)
        {
            return new BaseSpecification<Advertisement>(x => x.Discount!=null && x.Discount  == 60);
        }
        public static BaseSpecification<Advertisement> GetAdvertisementsByFilters(AdvertisementFilter filters, int pageNo, int pageSize)
        {
            Expression<Func<Advertisement, bool>> expression = null;
            Expression filterExpression = null;
            var parameter = Expression.Parameter(typeof(Advertisement), "Advertisement");

            if (filters.CategoryId != null)
            {
                var property = Expression.Property(parameter, "CategoryId");
                var propertyValue = Expression.Constant(filters.CategoryId);

                var isEqualExpression = Expression.Lambda<Func<Advertisement, bool>>(
                    Expression.And(
                        Expression.NotEqual(property, Expression.Constant(null)),
                     Expression.Equal(Expression.Convert(property, typeof(int)), propertyValue)
                    ), parameter);

                filterExpression = filterExpression != null ? Expression.AndAlso(filterExpression, isEqualExpression.Body) : isEqualExpression.Body;

            }
            if (filters.BrandId != null)
            {
                var property = Expression.Property(parameter, "BrandId");
                var propertyValue = Expression.Constant(filters.BrandId);
                var isEqualExpression = Expression.Lambda<Func<Advertisement, bool>>(
                    Expression.And(
                        Expression.NotEqual(property, Expression.Constant(null)),
                     Expression.Equal(Expression.Convert(property, typeof(int)), propertyValue)
                    ), parameter);
                filterExpression = filterExpression != null ? Expression.AndAlso(filterExpression, isEqualExpression.Body) : isEqualExpression.Body;
            }
            if (filters.Discount != null)
            {
                var property = Expression.Property(parameter, "Discount");
                var propertyValue = Expression.Constant((int)filters.Discount);

                var isEqualExpression = Expression.Lambda<Func<Advertisement, bool>>(
                    Expression.And(
                        Expression.NotEqual(property, Expression.Constant(null)),
                     Expression.Equal(Expression.Convert(property,typeof(int)), propertyValue)
                    ), parameter);
                filterExpression = filterExpression != null ? Expression.AndAlso(filterExpression, isEqualExpression.Body) : isEqualExpression.Body;
            }
            if (filters.Tag != null)
            {
                var property = Expression.Property(parameter, "Tag");
                var propertyValue = Expression.Constant(filters.Tag);
                var isEqualExpression = Expression.Lambda<Func<Advertisement, bool>>(
                    Expression.And(
                        Expression.NotEqual(property, Expression.Constant(null)),
                     Expression.Equal(Expression.Convert(property, typeof(int)), propertyValue)
                    ), parameter);
                filterExpression = filterExpression != null ? Expression.AndAlso(filterExpression, isEqualExpression.Body) : isEqualExpression.Body;
            }

            expression = Expression.Lambda<Func<Advertisement, bool>>(filterExpression, parameter);
            var spec = new BaseSpecification<Advertisement>(criteria: expression);
            spec.ApplyPaging(pageNo, pageSize);
            return spec;
        }
       
        public static BaseSpecification<Advertisement> GetAdvertisementsBypages( int pageNo, int pageSize)
        {
            var spec = new BaseSpecification<Advertisement>();
            spec.ApplyPaging(pageNo, pageSize);
            return spec;
        }

    }
}
