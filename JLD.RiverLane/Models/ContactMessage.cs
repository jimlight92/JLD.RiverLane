using System;
using BaseClasses.Fixtures;
using JLD.RiverLane.Models.Enums;

namespace JLD.RiverLane.Models
{
    public class ContactMessage : BaseClasses.Models.ContactMessage
    {
        /// <summary>
        /// Allows EF to intialise a new instance of the <see cref="ContactMessage"/> class
        /// </summary>
        protected ContactMessage() { }

        /// <summary>
        /// Initialises a new instance of the <see cref="ContactMessage"/> entity with the required fields
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="location"></param>
        /// <param name="message"></param>
        /// <param name="dateReceived"></param>
        /// <param name="weddingLocation"></param>
        /// <param name="weddingDate"></param>
        /// <param name="howDidYouFindMe"></param>
        public ContactMessage(string name, string email, string location, string message, DateTime dateReceived, 
            string weddingLocation, DateTime weddingDate, string howDidYouFindMe)
         : base(name, email, location, message, dateReceived)
        {
            Check.NotNullOrEmpty(weddingLocation, nameof(weddingLocation));
            Check.NotMinValue(weddingDate, nameof(weddingDate));
            Check.NotNullOrEmpty(howDidYouFindMe, nameof(howDidYouFindMe));

            WeddingLocation = weddingLocation;
            WeddingDate = weddingDate;
            HowDidYouFindMe = howDidYouFindMe;
        }

        public string WeddingLocation { get; set; }
        
        public DateTime WeddingDate { get; set; }

        public PackageType? PackageType { get; set; }
        
        public string HowDidYouFindMe { get; set; }
    }
}