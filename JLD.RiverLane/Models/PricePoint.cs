using BaseClasses.Fixtures;
using BaseClasses.Models;

namespace JLD.RiverLane.Models
{
    public class PricePoint : Entity
    {
        /// <summary>
        /// Allows EF to intialise a new instance of the <see cref="PricePoint"/> class
        /// </summary>
        protected PricePoint() { }

        /// <summary>
        /// Initialises a new instance of the <see cref="PricePoint"/> entity with the required fields
        /// </summary>
        /// <param name="description"></param>
        public PricePoint(string description)
        {
            Check.NotNullOrEmpty(description, nameof(description));
            Description = description;
        }
        
        public virtual Price Price { get; set; }
        
        public string Description { get; set; }
    }
}