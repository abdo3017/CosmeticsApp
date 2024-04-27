using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface ILocationService
    {
        Task<Customer_Address> Create(AddressDto address);
        void Delete(int id);
        Task<IList<Customer_Address>> GetAllByCustomerIdAsync(int CustomerId);

    }
}
