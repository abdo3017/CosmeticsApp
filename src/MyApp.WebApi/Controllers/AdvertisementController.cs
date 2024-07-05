using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.DTOs;


namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvertisementController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AdvertisementController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        [HttpGet("GetFilteredAdvertisements")]
        public async Task<IActionResult> GetFilteredAdvertisements(int pageNo, int pageSize, int? CatId, int? BrandId, int? Discount, string? Tag)
        {
            var filter = new AdvertisementFilter
            {
                CategoryId = CatId,
                BrandId = BrandId,
                Tag = Tag,
                Discount = Discount
            };
            var allAdvertisements = await _serviceManager.AdvertisementService.GetFilteredAdvertisements(filter, pageNo, pageSize);
            return Ok(
                new
                {
                    TotalCount = _serviceManager.AdvertisementService.TotalCount(),
                    Advertisements = allAdvertisements
                }
            );

        }

        [HttpGet("GetAllWithPaging")]
        public async Task<IActionResult> GetAllWithPaging(int pageNo, int pageSize)
        {
            var allAdvertisements = await _serviceManager.AdvertisementService.GetAllAdvertisements(pageNo,pageSize);
            return Ok(new
            {
                TotalCount = _serviceManager.BrandService.TotalCount(),
                Advertisements = allAdvertisements
            });
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
         
            var allAdvertisements = await _serviceManager.AdvertisementService.GetAllAdvertisements();
            return Ok(allAdvertisements);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var cat = await _serviceManager.AdvertisementService.GetAdvertisementById(id);
            return Ok(cat);
        }

        [HttpGet("GetAllCount")]
        public async Task<IActionResult> GetAllCount()
        {
            var cat = await _serviceManager.AdvertisementService.GetTotalCount();
            return Ok(cat);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AdvertisementDTO Advertisement)
        {
            var addedAdvertisement = await _serviceManager.AdvertisementService.CreateAdvertisement(Advertisement);
            return Created();
        }

        [HttpPut("Update")]
        public IActionResult Update(AdvertisementDTO Advertisement)
        {
            _serviceManager.AdvertisementService.UpdateAdvertisement(Advertisement);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            _serviceManager.AdvertisementService.DeleteAdvertisement(id);
            return Ok();
        }

        [HttpPost("UploadImg/{AdvId}")]
        public async Task<IActionResult> UploadImage(int AdvId, IFormFile file)
        {
            await _serviceManager.AdvertisementService.UploadImg(AdvId, file);
            return Ok();
        }
    }
}
