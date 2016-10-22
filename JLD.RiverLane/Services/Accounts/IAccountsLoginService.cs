using JLD.RiverLane.Security;
using JLD.RiverLane.ViewModels.Accounts;

namespace JLD.RiverLane.Services.Accounts
{
    public interface IAccountsLoginService
    {
        LoginModel Get();

        AuthenticationResult Post(LoginModel model);
    }
}