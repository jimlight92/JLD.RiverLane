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
        /// <param name="password"></param>
        public UserAccount(string username, string password)
        {
            Check.NotNullOrEmpty(username, nameof(username));
            Username = username;

            ChangePassword(password);
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
            var provider = GetHashProvider();
            var hash = provider.GenerateHash(password, PasswordSalt);

            return hash.Equals(PasswordHash);
        }

        protected virtual IHashProvider GetHashProvider()
        {
            return new HashProvider();
        }

        /// <summary>
        /// Changes the password of the user
        /// </summary>
        /// <param name="password"></param>
        public void ChangePassword(string password)
        {
            Check.NotNullOrEmpty(password, nameof(password));

            var provider = GetHashProvider();
            var pair = provider.GenerateHashAndSalt(password);
            PasswordHash = pair.Hash;
            PasswordSalt = pair.Salt;
        }
    }
}