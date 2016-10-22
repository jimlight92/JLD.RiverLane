namespace JLD.RiverLane.Services.Accounts
{
    public interface IAccountsUserService
    {
        void SignIn(string username);

        void LogOut();
    }
}