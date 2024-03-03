using MyApp.Domain.Enums;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;

namespace MyApp.Domain.Specifications
{
    public static class UserSpecifications
    {
        public static BaseSpecification<User> GetUserByEmailAndPasswordSpec(string emailId, string password)
        {
            return new BaseSpecification<User>(x => x.EmailId == emailId && x.Password == password && x.IsDeleted == false);
        }

       
    }
}
