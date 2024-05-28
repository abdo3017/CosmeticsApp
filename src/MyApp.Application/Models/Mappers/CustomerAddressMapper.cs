using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System.Globalization;

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
                Country=CultureInfo.CurrentCulture.Name=="en"?"KSA": "المملكة العربية السعودية",
                PostalCode ="0000",
                AreaAr = dto.AreaAr,
                CityAr = dto.CityAr
            };
        }
    }
}
