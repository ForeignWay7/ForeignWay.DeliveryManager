using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.App.Services
{
    public interface IConfirmationOverlay
    {
        Task ShowConfirmation(string title, string message);
    }
}