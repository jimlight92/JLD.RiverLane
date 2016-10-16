using AutoMapper;
using Ninject.Modules;
using Ninject.Web.Common;
using System.Reflection;

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

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfiles(Assembly.GetExecutingAssembly()));

            return config.CreateMapper();
        }
    }
}