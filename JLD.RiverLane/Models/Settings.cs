using System;

namespace JLD.RiverLane.Models
{
    public class Settings : Entity
    {
        /// <summary>
        /// Allows EF to intialise a new instance of the <see cref="Settings"/> class
        /// </summary>
        protected Settings()
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Settings"/> entity with the required fields
        /// </summary>
        /// <param name="contactEmail"></param>
        /// <param name="contactNumber"></param>
        /// <param name="contactAddress"></param>
        public Settings(string contactEmail, string contactNumber, Address contactAddress)
        {
            Check.NotNull(contactAddress, nameof(contactAddress));
            ContactAddress = contactAddress;

            ChangeContactEmail(contactEmail);
            ChangeContactNumber(contactNumber);
        }

        public virtual Address ContactAddress { get; protected set; }

        public string ContactEmail { get; protected set; }

        public string ContactNumber { get; protected set; }

        /// <summary>
        /// Changes the contact email
        /// </summary>
        /// <param name="contactEmail"></param>
        public void ChangeContactEmail(string contactEmail)
        {
            Check.NotNullOrEmpty(contactEmail, nameof(contactEmail));
            ContactEmail = contactEmail;
        }

        /// <summary>
        /// Changes the contact number
        /// </summary>
        /// <param name="contactNumber"></param>
        public void ChangeContactNumber(string contactNumber)
        {
            Check.NotNullOrEmpty(contactNumber, nameof(contactNumber));
            ContactNumber = contactNumber;
        }

        /// <summary>
        /// Changes the contact address
        /// </summary>
        /// <param name="houseName"></param>
        /// <param name="street"></param>
        /// <param name="town"></param>
        /// <param name="city"></param>
        /// <param name="postcode"></param>
        public void ChangeContactAddress(string houseName, string street, string town, string city, string postcode)
        {
            ContactAddress.HouseName = houseName;
            ContactAddress.Street = street;
            ContactAddress.Town = town;
            ContactAddress.City = city;
            ContactAddress.Postcode = postcode;
        }
    }
}