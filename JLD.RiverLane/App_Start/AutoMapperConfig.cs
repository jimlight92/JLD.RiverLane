using AutoMapper;
using System.Reflection;

namespace JLD.RiverLane
{
    public sealed class AutoMapperConfig
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfiles(Assembly.GetExecutingAssembly());
        }
    }
}