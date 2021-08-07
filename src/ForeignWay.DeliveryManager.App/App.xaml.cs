using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using ForeignWay.DeliveryManager.App.Helpers;
using ForeignWay.DeliveryManager.App.Views.Home;
using ForeignWay.DeliveryManager.App.Views.SignIn;

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
                string viewModelName;

                if (viewType.Name.EndsWith("View"))
                    viewModelName = viewType.Name.Replace("View", "ViewModel");
                else
                    viewModelName = $"{viewType.Name}ViewModel";

                var viewPath = viewType.FullName?.Substring(0, viewType.FullName.LastIndexOf(viewType.Name));
                var fullName = $"{viewPath}{viewModelName}";

                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelAssemblyName = $"{fullName}, {viewAssemblyName}";

                var viewModelType = Type.GetType(viewModelAssemblyName);

                if (viewModelType == null)
                    throw new FileNotFoundException($"The ViewModel {viewModelAssemblyName} could not be found");

                return viewModelType;
            });
        }
    }
}
