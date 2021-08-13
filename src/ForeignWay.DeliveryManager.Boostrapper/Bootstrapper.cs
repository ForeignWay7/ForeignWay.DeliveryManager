using ForeignWay.DeliveryManager.BusinessLogic;
using ForeignWay.DeliveryManager.BusinessLogic.Contracts.Users;
using ForeignWay.DeliveryManager.DatabaseAccess.Contracts.Users;
using ForeignWay.DeliveryManager.DatabaseAccess.Users;
using Prism.Ioc;

namespace ForeignWay.DeliveryManager.Bootstrapper
{
    public static class Bootstrapper
    {
        public static void Bootstrap(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IUserRepository, UserRepository>();
            containerRegistry.RegisterSingleton<IAuthenticationService, AuthenticationService>();
        }
    }
}