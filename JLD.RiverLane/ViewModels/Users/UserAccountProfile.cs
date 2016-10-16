using AutoMapper;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.ViewModels.Users
{
    public class UserAccountProfile : Profile
    {
        public UserAccountProfile()
        {
            CreateMap<UserAccount, UserModel>();
        }
    }
}