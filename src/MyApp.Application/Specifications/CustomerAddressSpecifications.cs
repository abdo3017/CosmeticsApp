using MyApp.Application.Core.Specifications;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Specifications
{
    public static class CustomerAddressSpecifications
    {
        public static BaseSpecification<Customer_Address> GetAllAddressByCustomerId(int id)
        {
            return new BaseSpecification<Customer_Address>(x => x.CustomerId == id);
        }
    }
}
