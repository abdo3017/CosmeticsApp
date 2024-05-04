using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Specifications;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using System.Data.Entity.Core.Metadata.Edm;

namespace MyApp.Application.Services
{
    public class ShipmentCostService : BaseService<ShipmentCost, int>, IShipmentCostService
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

        public async Task<ShipmentCost> AddCost(int ShipmentId, decimal Cost)
        {
            var Shipment = await GetByIdAsync(ShipmentId);
            if (Shipment != null)
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

        public async Task<ShipmentCost?> GetShipmentCostByAddressId(int addressId)
        {
            ShipmentCost? cost = null;
            var locationSpec = CustomerAddressSpecifications.GetAddressById(addressId);
            var locationRepo = _unitOfWork.Repository<Customer_Address, int>();
            var location = await locationRepo.FirstOrDefaultAsync(locationSpec);
            if (location != null)
            {
                var spec = ShipmentCostSpecifications.GetShipmentCostByAddress(location.City, location.Area);
                cost = await _repository.FirstOrDefaultAsync(spec);
            }
            return cost;
        }
    }
}
