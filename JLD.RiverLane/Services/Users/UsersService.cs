using JLD.RiverLane.Models;

namespace JLD.RiverLane.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersIndexService index;

        public UsersService(IUsersIndexService index)
        {
            Check.NotNull(index, nameof(index));

            this.index = index;
        }

        public IUsersIndexService Index
        {
            get { return index; }
        }
    }
}