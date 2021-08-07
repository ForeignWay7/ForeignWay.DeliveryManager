using ForeignWay.DeliveryManager.Types;
using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.BusinessLogic.Contracts
{
    public interface IAuthenticationService
    {
        Task<UserType> SignInFor(string userName, string password);
    }
}