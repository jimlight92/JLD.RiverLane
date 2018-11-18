using BaseClasses.Fixtures;
using BaseClasses.Helpers;
using BaseClasses.Models;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Models;
using JLD.RiverLane.ViewModels.Users;

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
            return new UserCreateModel();
        }

        public UserCreateModel Get(UserCreateModel model)
        {
            return model;
        }

        public UserAccount Post(UserCreateModel model)
        {
            var user = new UserAccount(model.Username);
            user.ChangePassword(model.PasswordDetails.Password);
            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }
    }
}