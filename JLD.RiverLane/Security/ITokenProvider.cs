using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;

namespace JLD.RiverLane.Security
{
    /// <summary>
    /// Provides methods for creating a token for the user's session.
    /// </summary>
    public interface ITokenProvider
    {
        /// <summary>
        /// Signs a user into the application.
        /// </summary>
        /// <param name="userName">The user name to sign in.</param>
        void SignIn(string userName);

        /// <summary>
        /// Signs a user out of the application.
        /// </summary>
        void SignOut();

        /// <summary>
        /// Gets the currently signed in user.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Performs a conversion.")]
        IPrincipal GetUser();
    }
}