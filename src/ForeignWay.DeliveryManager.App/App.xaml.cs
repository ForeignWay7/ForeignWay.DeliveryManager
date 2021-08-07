using ForeignWay.DeliveryManager.App.Helpers;
using ForeignWay.DeliveryManager.App.Services;
using ForeignWay.DeliveryManager.App.Views.Home;
using ForeignWay.DeliveryManager.App.Views.NewOrder;
using ForeignWay.DeliveryManager.App.Views.SignIn;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace ForeignWay.DeliveryManager.App
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Bootstrapper.Bootstrapper.Bootstrap(containerRegistry);

            containerRegistry.Register<IPasswordBoxHelper, PasswordBoxHelper>();
            containerRegistry.Register<IMenuItemsProviderService, MenuItemProviderService>();

            containerRegistry.Register<INavigationService, NavigationService>();

            RegisterViewsForNavigation(containerRegistry);
        }

        protected override void Initialize()
        {
            base.Initialize();

            RegisterViewsWithViewModels();
        }

        private void RegisterViewsForNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SignInView, SignInViewModel>();
            containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();
            containerRegistry.RegisterForNavigation<NewOrderView, NewOrderViewModel>();
        }

        private void RegisterViewsWithViewModels()
        {
            ViewModelLocationProvider.Register<Shell, ShellViewModel>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                var viewModelName = viewType.Name.EndsWith("View") ? viewType.Name.Replace("View", "ViewModel") : $"{viewType.Name}ViewModel";

                var viewPath = viewType.FullName?.Substring(0, viewType.FullName.LastIndexOf(viewType.Name));
                var fullName = $"{viewPath}{viewModelName}";

                var viewAssemblyFullName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelAssemblyFullName = $"{fullName}, {viewAssemblyFullName}";

                var viewModelType = Type.GetType(viewModelAssemblyFullName);

                if (viewModelType == null)
                    throw new FileNotFoundException($"The requested ViewModel:\"{viewModelAssemblyFullName}\" does not exist..");

                return viewModelType;
            });
        }
    }
}
