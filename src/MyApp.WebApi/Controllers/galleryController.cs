﻿using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.Mappers;
using MyApp.Domain.Entities;

namespace MyApp.WebApi.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class galleryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public galleryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("uploadProductImg/{proId}/{isCover}")]
        public async Task<IActionResult> UploadPicture(int proId, int isCover ,IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    
                    await _serviceManager.GalleryService.CreateImg(proId , isCover , file); 
                    return Ok();
                }
                else
                {
                    return BadRequest("Invalid file.");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}