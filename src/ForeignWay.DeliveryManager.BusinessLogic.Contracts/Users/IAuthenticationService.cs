using ForeignWay.DeliveryManager.Types.Users;
using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.BusinessLogic.Contracts.Users
{
    public interface IAuthenticationService
    {
        Task<UserType> SignInForAsync(string userName, string password);

        User GetCurrentUser();
    }
}