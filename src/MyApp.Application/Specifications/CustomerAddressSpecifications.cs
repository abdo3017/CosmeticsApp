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
        public static BaseSpecification<Customer_Address> GetAllAddressesByCustomerId(int id)
        {
            return new BaseSpecification<Customer_Address>(x => x.CustomerId == id);
        }
        public static BaseSpecification<Customer_Address> GetAddressById(int id)
        {
            return new BaseSpecification<Customer_Address>(x => x.Id == id);
        }
    }
}
