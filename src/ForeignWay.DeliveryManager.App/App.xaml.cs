using ForeignWay.DeliveryManager.App.Helpers;
using ForeignWay.DeliveryManager.App.Views.Home;
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
            containerRegistry.Register<IPasswordBoxHelper, PasswordBoxHelper>();
        }

        protected override void Initialize()
        {
            base.Initialize();

            _RegisterViewsWithViewModels();
        }

        private void _RegisterViewsWithViewModels()
        {
            ViewModelLocationProvider.Register<Shell, ShellViewModel>();
            ViewModelLocationProvider.Register<HomeView, HomeViewModel>();
            ViewModelLocationProvider.Register<SignInView, SignInViewModel>();
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
