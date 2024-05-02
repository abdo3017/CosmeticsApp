using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Specifications;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;
using System.Data.Entity.Core.Metadata.Edm;

namespace MyApp.Application.Services
{
    public class ShipmentCostService : BaseService<ShipmentCost, int>, IshipmentCostService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ShipmentCostService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShipmentCost> Create(ShipmentCost ShipCost)
        {
            var shipmentCost = await AddAsync(ShipCost);
            return shipmentCost;
        }

        public async Task<IEnumerable<IGrouping<string, ShipmentCost>>> GetShipmentAddress()
        {
            var res = await _repository.GetAllAsync();
            return res.GroupBy(q => q.Area);
        }

        public async Task<ShipmentCost> AddCost(int ShipmentId , decimal Cost)
        {
            var Shipment = await GetByIdAsync(ShipmentId);
            if(Shipment != null)
            {
               Shipment.Cost = Cost;
                _unitOfWork.SaveChanges();
            }
            return Shipment;
        }

        public async Task<IList<ShipmentCost>> GetShipmentsAsync(int PageNO, int PageSize)
        {
            var spec = ShipmentCostSpecifications.GetShipmentCostWithPaging(PageNO, PageSize);
            var res = await _repository.ListAsync(spec);
            return res;
        }

    }
}
