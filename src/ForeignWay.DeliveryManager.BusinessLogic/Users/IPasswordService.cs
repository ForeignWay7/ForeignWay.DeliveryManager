using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.BusinessLogic.Users
{
    public interface IPasswordService
    {
        Task<string> CreateHashAsync(string passwordText);
    }
}