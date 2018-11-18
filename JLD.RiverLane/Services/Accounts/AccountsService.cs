using BaseClasses.Fixtures;
using BaseClasses.Helpers;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.Services.Accounts
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsLoginService login;
        private readonly IAccountsUserService user;

        public AccountsService(IAccountsLoginService login, IAccountsUserService user)
        {
            Check.NotNull(login, nameof(login));
            Check.NotNull(user, nameof(user));

            this.login = login;
            this.user = user;
        }

        public IAccountsLoginService Index
        {
            get { return login; }
        }

        public IAccountsUserService User
        {
            get { return user; }
        }
    }
}