namespace JLD.RiverLane.Services.Users
{
    public interface IUsersService
    {
        IUsersIndexService Index { get; }

        IUserCreateService Create { get; }
    }
}