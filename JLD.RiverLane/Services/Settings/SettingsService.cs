using BaseClasses.Fixtures;
using BaseClasses.Helpers;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsEditService edit;

        public SettingsService(ISettingsEditService edit)
        {
            Check.NotNull(edit, nameof(edit));
            this.edit = edit;
        }

        public ISettingsEditService Edit
        {
            get { return edit; }
        }
    }
}