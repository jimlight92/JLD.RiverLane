using BaseClasses.Fixtures;
using BaseClasses.Models;

namespace JLD.RiverLane.Models
{
    public class ExtraAlbum : Entity
    {
        /// <summary>
        /// Allows EF to intialise a new instance of the <see cref="ExtraAlbum"/> class
        /// </summary>
        public ExtraAlbum() { }

        /// <summary>
        /// Initialises a new instance of the <see cref="ExtraAlbum"/> entity with the required fields
        /// </summary>
        /// <param name="title"></param>
        /// <param name="numberOfPages"></param>
        /// <param name="price"></param>
        /// <param name="extraText"></param>
        public ExtraAlbum(string title, int numberOfPages, double price, string extraText)
        {
            Check.NotNullOrEmpty(title, nameof(title));
            Check.NotNullOrEmpty(extraText, nameof(extraText));

            Title = title;
            NumberOfPages = numberOfPages;
            Price = price;
            ExtraText = extraText;
        }
        
        public string Title { get; set; }
        
        public int NumberOfPages { get; set; }
        
        public double Price { get; set; }
        
        public string ExtraText { get; set; }
    }
}