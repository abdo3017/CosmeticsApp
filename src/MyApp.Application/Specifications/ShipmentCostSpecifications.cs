using MyApp.Application.Core.Specifications;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Specifications
{
    static public class ShipmentCostSpecifications
    {
        public static BaseSpecification<ShipmentCost> GetShipmentCostWithPaging(int pageNo, int pageSize)
        {
            var spec = new BaseSpecification<ShipmentCost>();
            spec.ApplyPaging((pageNo - 1) * pageSize, pageSize);
            return spec;
        }

        public static BaseSpecification<ShipmentCost> GetShipmentAddress()
        {
            var spec = new BaseSpecification<ShipmentCost>();
            spec.ApplyGroupBy(x => x.Area);
            return spec;
        }
        public static BaseSpecification<ShipmentCost> GetShipmentCostByAddress(string city, string area)
        {
            return new BaseSpecification<ShipmentCost>(x => x.Area == area && x.City == city);
        }
    }
}
