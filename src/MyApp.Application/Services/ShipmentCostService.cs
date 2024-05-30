using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Mappers;
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

        public async Task<ShipmentCostDTO> Create(ShipmentCostDTO ShipCost)
        {
            var shipmentCost = await AddAsync(ShipCost.Map());
            return shipmentCost.Map() ;
        }

        public async Task<IEnumerable<IGrouping<string, ShipmentCostDTO>>> GetShipmentAddress()
        {
            var res = await _repository.GetAllAsync();
            var resDto = res.Select(x=>x.Map());
            return resDto.GroupBy(q => q.Area);
        }

        public async Task<ShipmentCostDTO> AddCost(int ShipmentId, decimal Cost)
        {
            var Shipment = await GetByIdAsync(ShipmentId);
            if (Shipment != null)
            {
                Shipment.Cost = Cost;
                _unitOfWork.SaveChanges();
            }
            return Shipment.Map();
        }

        public async Task<IList<ShipmentCostDTO>> GetShipmentsAsync(int PageNO, int PageSize)
        {
            var spec = ShipmentCostSpecifications.GetShipmentCostWithPaging(PageNO, PageSize);
            var res = await _repository.ListAsync(spec);
            return res.Select(x=>x.Map()).ToList();
        }

        public async Task<ShipmentCostDTO?> GetShipmentCostByAddressId(int addressId)
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
            return cost?.Map();
        }
    }
}
