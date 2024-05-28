using Microsoft.AspNetCore.Http;
using MyApp.Application.Models.DTOs;

namespace MyApp.Application.Interfaces
{
    public interface ICardTokenService
    {
        Task<CardTokenDTO> CreateCardToken(CardTokenDTO req);
        void UpdateCardToken(CardTokenDTO req);
        void DeleteCardToken(CardTokenDTO req);
        Task<List<CardTokenDTO>> GetAll();
        Task<List<CardTokenDTO>> GetCardTokensByCustomerId(int id);
    }
        
}