using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IShipmentCostService
    {
        Task<ShipmentCost> Create(ShipmentCost ShipCost);
        Task<ShipmentCost?> GetShipmentCostByAddressId(int addressId);
        Task<IEnumerable<IGrouping<string, ShipmentCost>>> GetShipmentAddress();
        Task<ShipmentCost> AddCost(int ShipmentId, decimal Cost);
        Task<IList<ShipmentCost>> GetShipmentsAsync(int PageNO, int PageSize);
    }
}
