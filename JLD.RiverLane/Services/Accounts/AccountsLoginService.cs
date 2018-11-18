using BaseClasses.Fixtures;
using BaseClasses.Helpers;
using BaseClasses.Security;
using JLD.RiverLane.ViewModels.Accounts;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Security;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.Services.Accounts
{
    public class AccountsLoginService : IAccountsLoginService
    {
        private readonly IAuthenticationProvider authenticationProvider;
        private readonly RiverLaneContext context;

        public AccountsLoginService(RiverLaneContext context, IAuthenticationProvider authenticationProvider)
        {
            Check.NotNull(context, nameof(context));
            Check.NotNull(authenticationProvider, nameof(authenticationProvider));

            this.context = context;
            this.authenticationProvider = authenticationProvider;
        }

        public LoginModel Get()
        {
            return new LoginModel();
        }

        public AuthenticationResult Post(LoginModel model)
        {
            return authenticationProvider.ValidateCredentials(model.Username, model.Password);
        }
    }
}