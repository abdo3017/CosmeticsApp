using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;

namespace MyApp.Application.Models.Mappers
{
    public static class CustomerAddressMapper
    {

        public static Customer_Address  Map (this AddressDto  dto)
        {
            return new Customer_Address
            {
                Area = dto.Area,
                City = dto.City,
                CustomerId = dto.CustomerId,
                Street = dto.Street,
                Country="KSA",
                PostalCode ="0000"
                

            };
        }
    }
}
