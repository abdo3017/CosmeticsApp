using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;

namespace MyApp.Application.Interfaces
{
    public interface IAdvertisementService
    {
        Task<AdvertisementDTO> CreateAdvertisement(AdvertisementDTO req);
        void UpdateAdvertisement(AdvertisementDTO req);
        void DeleteAdvertisement(AdvertisementDTO req);
        Task<List<AdvertisementDTO>> GetAllAdvertisements();
        Task<AdvertisementDTO?> GetAdvertisementById(int id);
        Task<List<AdvertisementDTO>?> GetFilteredAdvertisements(AdvertisementFilter filter);
    }
}