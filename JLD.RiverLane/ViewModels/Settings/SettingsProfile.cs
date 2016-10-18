using AutoMapper;

namespace JLD.RiverLane.ViewModels.Settings
{
    public class SettingsProfile : Profile
    {
        public SettingsProfile()
        {
            CreateMap<Models.Settings, SettingsEditModel>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.ContactAddress));
        }
    }
}