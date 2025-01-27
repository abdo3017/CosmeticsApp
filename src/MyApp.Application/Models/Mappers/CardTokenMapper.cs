﻿using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.Mappers
{
    public static class CardTokenMapper
    {
        public static CardToken Map(this CardTokenDTO dto)
        {
            return new CardToken
            {
                Id = dto.Id,
                CustomerId = dto.CustomerId,
                Token = dto.Token,
                LastDigit = dto.LastDigit
            };
        }

        public static CardTokenDTO Map(this CardToken dto)
        {
            return new CardTokenDTO
            {
                Id=dto.Id,
                CustomerId = dto.CustomerId,
                Token = dto.Token, 
                LastDigit = dto.LastDigit
            };
        }
    }
}
