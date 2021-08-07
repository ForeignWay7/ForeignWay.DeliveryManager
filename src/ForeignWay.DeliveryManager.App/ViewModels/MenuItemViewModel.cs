using MaterialDesignThemes.Wpf;
using Prism.Mvvm;

namespace ForeignWay.DeliveryManager.App.ViewModels
{
    public class MenuItemViewModel : BindableBase
    {

        private PackIconKind _icon;
        private string _displayName;
        private string _viewName;

        public PackIconKind Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        public string ViewName
        {
            get => _viewName;
            set => SetProperty(ref _viewName, value);
        }

        public MenuItemViewModel(PackIconKind icon, string displayName, string viewName)
        {
            _icon = icon;
            _displayName = displayName;
            _viewName = viewName;
        }
    }
}