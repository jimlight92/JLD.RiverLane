using JLD.RiverLane.Security;
using JLD.RiverLane.Services.Accounts;
using Ninject.Modules;

namespace JLD.RiverLane.Infrastructure.Ninject.ControllerModules
{
    public class AccountsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAccountsService>()
                .To<AccountsService>();

            Bind<IAccountsLoginService>()
                .To<AccountsLoginService>();

            Bind<IAccountsUserService>()
                .To<AccountsUserService>();



            Bind<IAuthenticationProvider>()
                .To<RiverLaneFormsAuthenticationProvider>();

            Bind<ITokenProvider>()
                .To<RiverLaneFormsTokenProvider>();
        }
    }
}