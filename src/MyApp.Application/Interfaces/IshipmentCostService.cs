using MyApp.Application.Models.DTOs;
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
        Task<ShipmentCostDTO> Create(ShipmentCostDTO ShipCost);
        Task<ShipmentCostDTO?> GetShipmentCostByAddressId(int addressId);
        Task<IEnumerable<IGrouping<string, ShipmentCostDTO>>> GetShipmentAddress();
        Task<ShipmentCostDTO> AddCost(int ShipmentId, decimal Cost);
        Task<IList<ShipmentCostDTO>> GetShipmentsAsync(int PageNO, int PageSize);
        Task DeleteAsync(int id);
    }
}
