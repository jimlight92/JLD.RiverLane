using Ninject.Modules;
using JLD.RiverLane.Services.Users;

namespace JLD.RiverLane.Infrastructure.Ninject.ControllerModules
{
    public class UsersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUsersService>()
                .To<UsersService>();

            Bind<IUsersIndexService>()
                .To<UsersIndexService>();

            Bind<IUserCreateService>()
                .To<UserCreateService>();
        }
    }
}