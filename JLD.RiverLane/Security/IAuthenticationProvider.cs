namespace JLD.RiverLane.Security
{
    /// <summary>
    /// Provides methods for authenticating users.
    /// </summary>
    public interface IAuthenticationProvider
    {
        /// <summary>
        /// Validates a set of credentials.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>Success if the credentials are valid, Locked if the account is locked, otherwise Failure.</returns>
        AuthenticationResult ValidateCredentials(string userName, string password);
    }
}
