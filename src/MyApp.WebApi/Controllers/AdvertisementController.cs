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

       
        [HttpPost("FilterAdvertisements")]
        public async Task<IActionResult> FilterAdvertisements(AdvertisementFilter filter)
        {
            var allAdvertisements = await _serviceManager.AdvertisementService.GetFilteredAdvertisements(filter);
            return Ok(allAdvertisements);

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
        public IActionResult Delete(AdvertisementDTO Advertisement)
        {
            _serviceManager.AdvertisementService.DeleteAdvertisement(Advertisement);
            return Ok();
        }

        [HttpPost("UploadImg/{AdvId}")]
        public async Task<IActionResult> UploadImage(int advertisementId, IFormFile file)
        {
            await _serviceManager.AdvertisementService.UploadImg(advertisementId, file);
            return Ok();
        }
    }
}
