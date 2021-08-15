using ForeignWay.DeliveryManager.BusinessLogic.Contracts.Users;
using ForeignWay.DeliveryManager.BusinessLogic.Users;
using ForeignWay.DeliveryManager.DatabaseAccess.Contracts.Users;
using ForeignWay.DeliveryManager.DatabaseAccess.Users;
using Prism.Ioc;

namespace ForeignWay.DeliveryManager.Bootstrapper
{
    public static class Bootstrapper
    {
        public static void Bootstrap(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IUsersService, UsersService>();
            containerRegistry.Register<IUserRepository, UserRepository>();
            containerRegistry.RegisterSingleton<IAuthenticationService, AuthenticationService>();
            containerRegistry.Register<IPasswordService, PasswordService>();
        }
    }
}