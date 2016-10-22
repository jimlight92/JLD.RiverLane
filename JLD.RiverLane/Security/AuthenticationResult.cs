using JLD.RiverLane.Infrastructure.Attributes;

namespace JLD.RiverLane.Security
{
    /// <summary>
    /// The result of an authentication process.
    /// </summary>
    public enum AuthenticationResult
    {
        /// <summary>
        /// Authentication successful.
        /// </summary>
        Success,

        /// <summary>
        /// Invalid logon credentials.
        /// </summary>
        [Message("The username or password was invalid")]
        InvalidCredentials
    }
}