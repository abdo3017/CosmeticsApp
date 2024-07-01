using MyApp.Application.Models.DTOs;
using Microsoft.AspNetCore.Http;

namespace MyApp.Application.Interfaces
{
    public interface IAdvertisementService
    {
        Task<AdvertisementDTO> CreateAdvertisement(AdvertisementDTO req);
        void UpdateAdvertisement(AdvertisementDTO req);
        void DeleteAdvertisement(int id);
        Task<List<AdvertisementDTO>> GetAllAdvertisements(int pageNo = 0, int pageSize = 0);
        Task<AdvertisementDTO?> GetAdvertisementById(int id);
        Task<List<AdvertisementDTO>?> GetFilteredAdvertisements(AdvertisementFilter filter, int pageNo, int pageSize);
        Task UploadImg(int AdvertisementId, IFormFile file);
        int TotalCount();
    }
}