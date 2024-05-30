using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System.Globalization;

namespace MyApp.Application.Models.Mappers
{
    public static class CustomerAddressMapper
    {

        public static Customer_Address Map(this AddressDto dto)
        {
            return new Customer_Address
            {
                Area = dto.Area,
                City = dto.City,
                CustomerId = dto.CustomerId,
                Street = dto.Street,
                Country = "KSA",
                CountryAr = "المملكة العربية السعودية",
                PostalCode = "0000",
                AreaAr = dto.AreaAr,
                CityAr = dto.CityAr
            };
        }
        public static AddressDto Map(this Customer_Address dto)
        {
            return new AddressDto
            {
                Area = CultureInfo.CurrentCulture.Name == "en" ? dto.Area : (dto.AreaAr ?? dto.Area),
                City = CultureInfo.CurrentCulture.Name == "en" ? dto.City : (dto.CityAr ?? dto.City),
                CustomerId = dto.CustomerId,
                Street = dto.Street,
                Country = CultureInfo.CurrentCulture.Name == "en" ? dto.Country : dto.CountryAr,
                PostalCode = dto.PostalCode
            };
        }
    }
}
