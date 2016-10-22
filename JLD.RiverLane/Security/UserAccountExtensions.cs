using System.Linq;
using System.Security.Principal;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.Security
{
    public static class UserAccountExtensions
    {
        /// <summary>
        /// Retrieves the user account which corresponds to an IPrincipal.
        /// </summary>
        /// <param name="userAccounts">The collection of user accounts to search.</param>
        /// <param name="user">The user to search for.</param>
        public static UserAccount FindUser(this IQueryable<UserAccount> userAccounts, IPrincipal user)
        {
            Check.NotNull(user, nameof(user));

            return userAccounts.FirstOrDefault(x => x.Username.ToUpper() == user.Identity.Name.ToUpper());
        }

        /// <summary>
        /// Retrieves the user account with the specified user name.
        /// </summary>
        /// <param name="userAccounts">The collection of user accounts to search.</param>
        /// <param name="userName">The name of the user to find.</param>
        public static UserAccount FindUser(this IQueryable<UserAccount> userAccounts, string userName)
        {
            Check.NotNull(userAccounts, nameof(userAccounts));

            return userAccounts.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());
        }
    }
}