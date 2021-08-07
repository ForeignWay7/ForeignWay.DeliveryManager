using ForeignWay.DeliveryManager.BusinessLogic.Contracts;
using ForeignWay.DeliveryManager.Types;
using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.BusinessLogic
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<UserType> SignInFor(string userName, string password)
        {
            return Task.FromResult(UserType.Employee);
        }
    }
}