using MyApp.Domain.Enums;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Application.Core.Specifications;

namespace MyApp.Application.Specifications
{
    public static class UserSpecifications
    {
        public static BaseSpecification<User> GetUserByEmailAndPasswordSpec(string emailId, string password)
        {
            return new BaseSpecification<User>(x => x.EmailId == emailId && x.Password == password && x.IsDeleted == false);
        }

       
    }
}
