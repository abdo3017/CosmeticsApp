using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.Mappers
{
    public static class CustomerMapper
    {
        public static UserDTO Map(this User dto)
        {
            return new UserDTO
            {
               Id = dto.Id,
               FirstName = dto.FirstName,
               LastName = dto.LastName,
               EmailId = dto.Email,
               Username = dto.UserName
            };
        }
    }
}
