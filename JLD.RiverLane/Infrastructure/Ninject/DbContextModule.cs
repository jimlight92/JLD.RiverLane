using JLD.RiverLane.DataAccess;
using Ninject.Modules;
using Ninject.Web.Common;

namespace JLD.RiverLane.Infrastructure.Ninject
{
    public class DbContextModule : NinjectModule
    {
        public override void Load()
        {
            Bind<RiverLaneContext>()
                .ToSelf()
                .InRequestScope();
        }
    }
}