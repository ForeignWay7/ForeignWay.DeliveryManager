using Prism.Ioc;
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

        }
    }
}
