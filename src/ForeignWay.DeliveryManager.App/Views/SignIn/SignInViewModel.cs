using ForeignWay.DeliveryManager.App.Helpers;
using Prism.Commands;
using Prism.Mvvm;

namespace ForeignWay.DeliveryManager.App.Views.SignIn
{
    public class SignInViewModel : BindableBase
    {
        private readonly IPasswordBoxHelper _passwordBoxHelper;

        private string _userName;
        private DelegateCommand<object> _logInCommand;


        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }


        public DelegateCommand<object> LogInCommand
        {
            get => _logInCommand;
            set => SetProperty(ref _logInCommand, value);
        }


        public SignInViewModel(IPasswordBoxHelper passwordBoxHelper)
        {
            _passwordBoxHelper = passwordBoxHelper;

            LogInCommand = new DelegateCommand<object>(LogIn);
        }


        private void LogIn(object passwordObject)
        {
            var password = _passwordBoxHelper.GetPasswordFrom(passwordObject);


        }
    }
}