using AutoMapper;
using BaseClasses.Models;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.ViewModels.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAccount, UserModel>();
        }
    }
}