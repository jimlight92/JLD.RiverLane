using JLD.RiverLane.Services.Home;
using Ninject.Modules;

namespace JLD.RiverLane.Infrastructure.Ninject.ControllerModules
{
    public class HomeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHomeService>()
                .To<HomeService>();

            Bind<IHomeIndexService>()
                .To<HomeIndexService>();
        }
    }
}