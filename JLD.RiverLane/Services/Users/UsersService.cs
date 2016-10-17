using JLD.RiverLane.Models;

namespace JLD.RiverLane.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersIndexService index;
        private readonly IUserCreateService create;

        public UsersService(IUsersIndexService index, IUserCreateService create)
        {
            Check.NotNull(index, nameof(index));
            Check.NotNull(create, nameof(create));

            this.index = index;
            this.create = create;
        }

        public IUsersIndexService Index
        {
            get { return index; }
        }

        public IUserCreateService Create
        {
            get { return create; }
        }
    }
}