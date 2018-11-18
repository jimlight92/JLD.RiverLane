using BaseClasses.Fixtures;

namespace JLD.RiverLane.Services.Users
{
    public class UsersService : IUsersService
    {
        public UsersService(IUsersIndexService index, IUserCreateService create)
        {
            Check.NotNull(index, nameof(index));
            Check.NotNull(create, nameof(create));

            Index = index;
            Create = create;
        }

        public IUsersIndexService Index { get; }

        public IUserCreateService Create { get; }
    }
}