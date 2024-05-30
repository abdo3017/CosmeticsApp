using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;
using MyApp.Application.Models.Mappers;
using System.Data.Entity.Validation;
using MyApp.Application.Specifications;

namespace MyApp.Application.Services
{
    public class LocationService : BaseService<Customer_Address, int>, ILocationService
    {
        public LocationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<AddressDto> Create(AddressDto address)
        {
            Customer_Address customer_address = address.Map();
            var res = await AddAsync(customer_address);
            return res.Map();
        }

        public void Delete(int id)
        {
           DeleteById(id);
        }

        public async Task<IList<AddressDto>> GetAllByCustomerIdAsync(int CustomerId)
        {
             var spec = CustomerAddressSpecifications.GetAllAddressesByCustomerId(CustomerId);
             var res = await _repository.ListAsync(spec);
            return res.Select(s=>s.Map()).ToList(); 
        }
    }
}
