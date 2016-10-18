using JLD.RiverLane.ViewModels.Addresses;

namespace JLD.RiverLane.ViewModels.Settings
{
    public class SettingsEditModel
    {
        public string ContactEmail { get; set; }

        public string ContactNumber { get; set; }

        public AddressModel Address { get; set; }
    }
}