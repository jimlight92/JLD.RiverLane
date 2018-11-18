using AutoMapper;
using BaseClasses.Fixtures;
using BaseClasses.Helpers;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Models;
using JLD.RiverLane.ViewModels.Settings;

namespace JLD.RiverLane.Services.Settings
{
    public class SettingsEditService : ISettingsEditService
    {
        private readonly RiverLaneContext context;
        private readonly IMapper mapper;

        public SettingsEditService(RiverLaneContext context, IMapper mapper)
        {
            Check.NotNull(context, nameof(context));
            Check.NotNull(mapper, nameof(mapper));

            this.context = context;
            this.mapper = mapper;
        }

        public SettingsEditModel Get()
        {
            var settings = context.Settings;
            return mapper.Map<SettingsEditModel>(settings);
        }

        public SettingsEditModel Get(SettingsEditModel model)
        {
            return model;
        }

        public Models.Settings Post(SettingsEditModel model)
        {
            var settings = context.Settings;
            settings.ChangeContactEmail(model.ContactEmail);
            settings.ChangeContactNumber(model.ContactNumber);
            settings.ChangeContactAddress(model.Address.HouseName, model.Address.Street, model.Address.Town, model.Address.City, model.Address.Postcode);

            context.SaveChanges();

            return settings;
        }
    }
}