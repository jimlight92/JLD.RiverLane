using System.Collections.Generic;
using BaseClasses.Fixtures;
using BaseClasses.Models;
using JLD.RiverLane.Models.Enums;

namespace JLD.RiverLane.Models
{
    public class Price : Entity
    {
        /// <summary>
        /// Allows EF to intialise a new instance of the <see cref="Price"/> class
        /// </summary>
        protected Price() { }

        /// <summary>
        /// Initialises a new instance of the <see cref="Price"/> entity with the required fields
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="value"></param>
        /// <param name="package"></param>
        public Price(string title, string description, double value, PackageType package)
        {
            Check.NotNullOrEmpty(title, nameof(title));
            Check.NotNullOrEmpty(description, nameof(description));

            Title = title;
            Description = description;
            Value = value;
            PackageType = package;

            ExtraPoints = new List<PricePoint>();
        }

        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public double Value { get; set; }
        
        public PackageType PackageType { get; set; }
        
        public ICollection<PricePoint> ExtraPoints { get; set; }

        public void AddPricePoint(string desc)
        {
            ExtraPoints.Add(new PricePoint(desc));
        }
    }
}