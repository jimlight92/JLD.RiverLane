using BaseClasses.Fixtures;
using BaseClasses.Models;
using JLD.RiverLane.Models.Enums;

namespace JLD.RiverLane.Models
{
    public class Recommend : Entity
    {
        /// <summary>
        /// Allows EF to intialise a new instance of the <see cref="Recommend"/> class
        /// </summary>
        public Recommend() { }

        /// <summary>
        /// Initialises a new instance of the <see cref="Recommend"/> entity with the required fields
        /// </summary>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="url"></param>
        /// <param name="webText"></param>
        /// <param name="location"></param>
        public Recommend(string name, string desc, string phone, string email, string url, string webText, LocationType location)
        {
            Check.NotNullOrEmpty(name, nameof(name));
            Check.NotNullOrEmpty(desc, nameof(desc));
            Check.NotNullOrEmpty(phone, nameof(phone));
            Check.NotNullOrEmpty(email, nameof(email));
            Check.NotNullOrEmpty(url, nameof(url));
            Check.NotNullOrEmpty(webText, nameof(webText));

            CompanyName = name;
            CompanyDescription = desc;
            Phone = phone;
            Email = email;
            WebsiteUrl = url;
            WebsiteText = webText;
            Location = location;
        }
        
        public string CompanyName { get; set; }
        
        public string CompanyDescription { get; set; }
        
        public string Phone { get; set; }
        
        public string Email { get; set; }
        
        public string WebsiteUrl { get; set; }
        
        public string WebsiteText { get; set; }

        public LocationType Location { get; set; }
    }
}