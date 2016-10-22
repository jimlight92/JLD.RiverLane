using JLD.RiverLane.Services.Settings;
using Ninject.Modules;

namespace JLD.RiverLane.Infrastructure.Ninject.ControllerModules
{
    public class SettingsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISettingsService>()
                .To<SettingsService>();

            Bind<ISettingsEditService>()
                .To<SettingsEditService>();
        }
    }
}