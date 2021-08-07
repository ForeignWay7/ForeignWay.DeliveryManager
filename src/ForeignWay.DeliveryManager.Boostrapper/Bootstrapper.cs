using ForeignWay.DeliveryManager.BusinessLogic;
using ForeignWay.DeliveryManager.BusinessLogic.Contracts;
using Prism.Ioc;

namespace ForeignWay.DeliveryManager.Bootstrapper
{
    public static class Bootstrapper
    {
        public static void Bootstrap(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IAuthenticationService, AuthenticationService>();
        }
    }
}