using BaseClasses.Models;

namespace JLD.RiverLane.Models
{
    public class Address : Entity
    {
        public string HouseName { get; set; }

        public string Street { get; set; }

        public string Town { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }
    }
}