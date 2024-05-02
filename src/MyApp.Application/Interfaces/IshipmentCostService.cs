using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IshipmentCostService
    {
        Task<ShipmentCost> Create(ShipmentCost ShipCost);
        Task<IEnumerable<IGrouping<string, ShipmentCost>>> GetShipmentAddress();
        Task<ShipmentCost> AddCost(int ShipmentId, decimal Cost);
        Task<IList<ShipmentCost>> GetShipmentsAsync(int PageNO, int PageSize);
    }
}
