using MyApp.Domain.Enums;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Application.Core.Specifications;

namespace MyApp.Application.Specifications
{
    public static class UserSpecifications
    {

        public static BaseSpecification<User> GetCustomerWithPaging(int pageNo, int pageSize)
        {
            var spec = new BaseSpecification<User>(u => u.RoleId == 3) ;
            spec.ApplyPaging(pageNo , pageSize);
            return spec;
        }
        public static BaseSpecification<User> GetCustomers()
        {
            var spec = new BaseSpecification<User>(u => u.RoleId == 3);
            return spec;
        }

    }
}
