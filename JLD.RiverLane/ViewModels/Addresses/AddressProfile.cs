using AutoMapper;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.ViewModels.Addresses
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressModel>();
        }
    }
}