using JLD.RiverLane.Infrastructure.FluentValidation;
using Ninject.Modules;

namespace JLD.RiverLane.Infrastructure.Ninject
{
    public class ContextFactoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IContextFactory>().To<ContextFactory>();
        }
    }
}