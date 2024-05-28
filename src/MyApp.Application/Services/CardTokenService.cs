using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Mappers;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Application.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyApp.Application.Services
{
    public class CardTokenService : BaseService<CardToken, int>, ICardTokenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CardTokenService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CardTokenDTO> CreateCardToken(CardTokenDTO req)
        {
            var CardToken = req.Map();

            var AddedCardToken = await AddAsync(CardToken);

            var dtoCardToken = AddedCardToken.Map();

            return dtoCardToken;
        }

        public void DeleteCardToken(CardTokenDTO req)
        {
            var CardToken = req.Map();

            Delete(CardToken);
        }

        public async Task<List<CardTokenDTO>> GetAll()
        {
            var categories = await _repository.GetAllAsync();

            var categoriesDto = categories.Select(s => s.Map()).ToList();

            return categoriesDto;
        }

        public async Task<List<CardTokenDTO>> GetCardTokensByCustomerId(int id)
        {
            var specification = CardTokenSpecifications.GetCardTokensByCustomerId(id);

            var cardTokenList = await _repository.ListAsync(specification);

            var dtoCardTokenList = cardTokenList.Select(s => s.Map()).ToList();

            return dtoCardTokenList;
        }

     
        public void UpdateCardToken(CardTokenDTO req)
        {
            var CardToken = req.Map();

            Update(CardToken);
        }
    }
}
