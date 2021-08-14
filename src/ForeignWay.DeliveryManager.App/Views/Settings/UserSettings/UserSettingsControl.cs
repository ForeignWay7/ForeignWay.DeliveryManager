using Prism.Mvvm;

namespace ForeignWay.DeliveryManager.App.Views.Settings.UserSettings
{
    public class UserSettingsControlViewModel : BindableBase
    {
        private string _searchTerm;

        public string SearchTerm
        {
            get => _searchTerm;
            set => SetProperty(ref _searchTerm, value);
        }


    }
}