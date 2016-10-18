using JLD.RiverLane.Models;
using JLD.RiverLane.ViewModels.Settings;

namespace JLD.RiverLane.Services.Settings
{
    public interface ISettingsEditService
    {
        SettingsEditModel Get();
        SettingsEditModel Get(SettingsEditModel model);
        Models.Settings Post(SettingsEditModel model);
    }
}