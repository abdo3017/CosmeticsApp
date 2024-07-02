using MyApp.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IList<UserDTO>> GetCustomers(int PageNO, int PageSize);
        Task<int> GetCustomersCount();
    }  
}
