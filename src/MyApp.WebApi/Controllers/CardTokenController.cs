using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.DTOs;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardTokenController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CardTokenController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var allCards = await _serviceManager.CardTokenService.GetAll();
            return Ok(allCards);
        }


        [HttpGet("GetCardTokensByCustomerId")]
        public async Task<IActionResult> GetBrandsByCategoryId(int id)
        {
            var allCards = await _serviceManager.CardTokenService.GetCardTokensByCustomerId(id);
            return Ok(allCards);

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CardTokenDTO tokenDTO)
        {
            var addedToken = await _serviceManager.CardTokenService.CreateCardToken(tokenDTO);
            return Created();
        }

        [HttpPut("Update")]
        public IActionResult Update(CardTokenDTO tokenDTO)
        {
            _serviceManager.CardTokenService.UpdateCardToken(tokenDTO);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(CardTokenDTO tokenDTO)
        {
            _serviceManager.CardTokenService.DeleteCardToken(tokenDTO);
            return Ok();
        }

    }
}
