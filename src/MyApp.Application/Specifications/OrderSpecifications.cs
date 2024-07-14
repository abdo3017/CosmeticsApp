using MyApp.Application.Core.Specifications;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Specifications
{
    public static class OrderSpecifications
    {
        public static BaseSpecification<Order> GetOrderById(int id)
        {
            return new BaseSpecification<Order>(x => x.Id == id);
        }
        public static BaseSpecification<Order> GetOrderWithDetailsById(int id)
        {
            var specs = new BaseSpecification<Order>(x => x.Id == id);
            specs.AddInclude(x => x.OrderDetails);
            return specs;
        }

        public static BaseSpecification<Order> GetOrderWithpageing(int pageNo, int pageSize, int orderType )
        {
            var spec = new BaseSpecification<Order>(o => o.Type == orderType);
            spec.ApplyPaging(pageNo, pageSize);
            return spec;
        }

        public static BaseSpecification<Order> GetOrderByType(int type)
        {
            return new BaseSpecification<Order>(x => x.Type== type);
        }
    }
}
