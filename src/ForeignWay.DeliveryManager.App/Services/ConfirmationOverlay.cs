using MahApps.Metro.Controls.Dialogs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ForeignWay.DeliveryManager.App.Services
{
    public class ConfirmationOverlay : IConfirmationOverlay
    {
        public async Task ShowConfirmation(string title, string message)
        {
            try
            {
                var homeView = Application.Current.Windows.OfType<Shell>().FirstOrDefault();
                await Application.Current.Dispatcher.InvokeAsync(async () => await homeView.ShowMessageAsync(title, message));
            }
            catch (Exception)
            {
                MessageBox.Show(message, title);
            }
        }
    }
}