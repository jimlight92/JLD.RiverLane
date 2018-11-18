using AutoMapper;
using Ninject.Modules;
using Ninject.Web.Common;

namespace JLD.RiverLane.Infrastructure.Ninject
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>()
                .ToMethod(x => CreateMapper())
                .InRequestScope();
        }

        private static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(AutoMapperConfig.Configure);

            return config.CreateMapper();
        }

    }
}