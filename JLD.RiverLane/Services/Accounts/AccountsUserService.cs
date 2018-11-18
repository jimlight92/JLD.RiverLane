using BaseClasses.Fixtures;
using BaseClasses.Helpers;
using BaseClasses.Security;
using JLD.RiverLane.Models;
using JLD.RiverLane.Security;

namespace JLD.RiverLane.Services.Accounts
{
    public class AccountsUserService : IAccountsUserService
    {
        private readonly ITokenProvider tokenProvider;

        public AccountsUserService(ITokenProvider tokenProvider)
        {
            Check.NotNull(tokenProvider, nameof(tokenProvider));
            
            this.tokenProvider = tokenProvider;
        }

        public void SignIn(string username)
        {
            tokenProvider.SignIn(username);
        }

        public void LogOut()
        {
            tokenProvider.SignOut();
        }
    }
}