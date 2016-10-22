using JLD.RiverLane.Models;

namespace JLD.RiverLane.Security
{
    /// <summary>
    /// Provides methods for authenticating users using Forms Authentication
    /// </summary>
    public abstract class FormsAuthenticationProvider : IAuthenticationProvider
    {
        /// <summary>
        /// Validates a set of credentials.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>Success if the credentials are valid, Locked if the account is locked, otherwise Failure.</returns>
        public AuthenticationResult ValidateCredentials(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return AuthenticationResult.InvalidCredentials;
            }

            var userAccount = GetUser(userName);

            if (userAccount == null || !userAccount.PasswordIsMatch(password))
            {
                return AuthenticationResult.InvalidCredentials;
            }

            return GetAuthenticationResult(userAccount);
        }

        /// <summary>
        /// Returns the <see cref="UserAccount"/> associated with the given userName and password.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        protected abstract UserAccount GetUser(string userName);

        /// <summary>
        /// Returns the outcome of the user's logon attempt
        /// </summary>
        /// <param name="user">The account being authenticated.</param>
        protected abstract AuthenticationResult GetAuthenticationResult(UserAccount user);
    }
}
