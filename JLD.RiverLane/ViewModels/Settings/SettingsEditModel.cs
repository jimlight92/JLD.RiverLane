using JLD.RiverLane.ViewModels.Addresses;
using System.ComponentModel.DataAnnotations;

namespace JLD.RiverLane.ViewModels.Settings
{
    public class SettingsEditModel
    {
        [Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }

        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        public AddressModel Address { get; set; }
    }
}