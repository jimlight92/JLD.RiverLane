using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Models;
using JLD.RiverLane.ViewModels.Users;
using System;

namespace JLD.RiverLane.Services.Users
{
    public class UserCreateService : IUserCreateService
    {
        private readonly RiverLaneContext context;

        public UserCreateService(RiverLaneContext context)
        {
            Check.NotNull(context, nameof(context));
            this.context = context;
        }

        public UserCreateModel Get()
        {
            throw new NotImplementedException();
        }

        public UserCreateModel Get(UserCreateModel model)
        {
            throw new NotImplementedException();
        }

        public UserAccount Post(UserCreateModel model)
        {
            throw new NotImplementedException();
        }
    }
}