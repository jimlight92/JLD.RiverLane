using BaseClasses.Models;

namespace JLD.RiverLane.Models
{
    public class Address : Entity
    {
        /// <summary>
        /// Allows EF to intialise a new instance of the <see cref="Address"/> class
        /// </summary>
        public Address() { }

        public string HouseName { get; set; }

        public string Street { get; set; }

        public string Town { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }
    }
}