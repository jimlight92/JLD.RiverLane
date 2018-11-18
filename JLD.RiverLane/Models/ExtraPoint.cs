using BaseClasses.Fixtures;
using BaseClasses.Models;

namespace JLD.RiverLane.Models
{
    public class ExtraPoint : Entity
    {
        /// <summary>
        /// Allows EF to intialise a new instance of the <see cref="PricePoint"/> class
        /// </summary>
        protected ExtraPoint() { }

        /// <summary>
        /// Initialises a new instance of the <see cref="ExtraPoint"/> entity with the required fields
        /// </summary>
        /// <param name="text"></param>
        public ExtraPoint(string text)
        {
            Check.NotNullOrEmpty(text, nameof(text));
            Text = text;
        }

        public string Text { get; set; }
    }
}