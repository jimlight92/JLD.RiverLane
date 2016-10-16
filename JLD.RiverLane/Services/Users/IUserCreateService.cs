using JLD.RiverLane.Models;
using JLD.RiverLane.ViewModels.Users;

namespace JLD.RiverLane.Services.Users
{
    public interface IUserCreateService
    {
        UserCreateModel Get();

        UserCreateModel Get(UserCreateModel model);

        UserAccount Post(UserCreateModel model);
    }
}