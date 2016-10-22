using System.ComponentModel.DataAnnotations;

namespace JLD.RiverLane.ViewModels.Addresses
{
    public class AddressModel
    {
        [Display(Name = "House Name")]
        public string HouseName { get; set; }

        public string Street { get; set; }

        public string Town { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }
    }
}