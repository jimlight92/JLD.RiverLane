namespace JLD.RiverLane.Services.Accounts
{
    public interface IAccountsService
    {
        IAccountsLoginService Index { get; }

        IAccountsUserService User { get; }
    }
}