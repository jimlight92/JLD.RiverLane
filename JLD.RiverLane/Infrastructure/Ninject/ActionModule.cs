using JLD.RiverLane.Actions.Commands;
using JLD.RiverLane.Actions.Queries;
using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace JLD.RiverLane.Infrastructure.Ninject
{
    public class ActionModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x =>
                x.FromThisAssembly()
                    .SelectAllInterfaces()
                    .InheritedFrom(typeof(ICommand<,>))
                    .BindAllInterfaces());

            this.Bind(x =>
                x.FromThisAssembly()
                    .SelectAllInterfaces()
                    .InheritedFrom(typeof(IQuery<,>))
                    .BindAllInterfaces());
        }
    }
}