using JLD.RiverLane.Services;
using Ninject.Modules;

namespace JLD.RiverLane.Infrastructure.Ninject
{
    public class SharedModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISlideshowResolver>()
                .To<SlideshowResolver>();
        }
    }
}