using JLD.RiverLane.Security;

namespace JLD.RiverLane.Models
{
    public class UserAccount : Entity
    {
        /// <summary>
        /// Allows EF to initialise a new instacne of the <see cref="UserAccount"/> class
        /// </summary>
        protected UserAccount()
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="UserAccount"/> class with the required fields
        /// </summary>
        /// <param name="username"></param>
        public UserAccount(string username)
        {
            Check.NotNullOrEmpty(username, nameof(username));
            Username = username;
        }

        public string Username { get; protected set; }

        public string PasswordHash { get; protected set; }

        public string PasswordSalt { get; protected set; }

        /// <summary>
        /// Indicates whether the given password is equal to the password currently stored in the database
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool PasswordIsMatch(string password)
        {
            var hash = Provider.GenerateHash(password, PasswordSalt);

            return hash.Equals(PasswordHash);
        }

        private IHashProvider provider;
        /// <summary>
        /// Gets or sets the hash provider used to store and verify passwords.
        /// </summary>
        protected virtual IHashProvider Provider
        {
            get
            {
                if (provider == null)
                {
                    provider = new HashProvider();
                }

                return provider;
            }
            set
            {
                provider = value;
            }
        }

        /// <summary>
        /// Changes the password of the user
        /// </summary>
        /// <param name="password"></param>
        public void ChangePassword(string password)
        {
            Check.NotNullOrEmpty(password, nameof(password));
            
            var pair = Provider.GenerateHashAndSalt(password);
            PasswordHash = pair.Hash;
            PasswordSalt = pair.Salt;
        }
    }
}