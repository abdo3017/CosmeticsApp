using MyApp.Application.Models.DTOs;
using Microsoft.AspNetCore.Http;

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
        Task UploadImg(int AdvertisementId, IFormFile file);
    }
}