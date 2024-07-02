using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Mappers;
using MyApp.Application.Specifications;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{

    public class CustomerService : BaseService<User, int>, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IList<UserDTO>> GetCustomers(int PageNO, int PageSize)
        {
            var spec = UserSpecifications.GetCustomerWithPaging(PageNO, PageSize);
            var customers  = await  _repository.ListAsync(spec);
            var res = customers.Select(u => u.Map()).ToList();
            return res;
        }

        public async Task<int> GetCustomersCount()
        {
            var spec = UserSpecifications.GetCustomers();
            var customers = await _repository.ListAsync(spec);
            var res = customers.Count();
            return res;
        }
    }
}
