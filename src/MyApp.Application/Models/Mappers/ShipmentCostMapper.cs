using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System.Globalization;

namespace MyApp.Application.Models.Mappers
{
    public static class ShipmentCostMapper
    {

        public static ShipmentCost Map(this ShipmentCostDTO dto)
        {
            return new ShipmentCost
            {
                Area = dto.Area,
                City = dto.City,
                Cost = dto.Cost,
                Id = dto.Id,
                AreaAr = dto.AreaAr,
                CityAr = dto.CityAr
            };
        }
        public static ShipmentCostDTO Map(this ShipmentCost dto)
        {
            return new ShipmentCostDTO
            {
                Area = CultureInfo.CurrentCulture.Name == "en" ? dto.Area:dto.AreaAr,
                City = CultureInfo.CurrentCulture.Name == "en" ? dto.City : dto.CityAr,
                Cost = dto.Cost,
                Id = dto.Id,
                AreaAr = dto.AreaAr,
                CityAr = dto.CityAr
            };
        }

    }
}
