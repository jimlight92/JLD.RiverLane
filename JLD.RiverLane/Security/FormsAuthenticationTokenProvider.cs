using JLD.RiverLane.Models;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace JLD.RiverLane.Security
{
    /// <summary>
    /// Provides methods for creating a token for the user's session.
    /// </summary>
    public abstract class FormsAuthenticationTokenProvider : ITokenProvider
    {
        /// <summary>
        /// Gets the currently signed in user.
        /// </summary>
        public IPrincipal GetUser()
        {
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                return null;
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var userName = ticket.Name;
            var userAccount = GetUserAccount(userName);

            if (userAccount == null)
            {
                return null;
            }
            else
            {
                return GetPrincipalFromUserAccount(userAccount);
            }
        }

        /// <summary>
        /// Retrieves <see cref="UserAccount"/> from database based on given user name.
        /// </summary>
        /// <param name="userName">The user name of the user to retrieve.</param>
        protected abstract UserAccount GetUserAccount(string userName);

        /// <summary>
        /// Returns an IPrincipal created using the given <see cref="UserAccount"/> .
        /// </summary>
        /// <param name="userAccount">The user account.</param>
        protected abstract IPrincipal GetPrincipalFromUserAccount(UserAccount userAccount);

        /// <summary>
        /// Creates a token for the user and stores it as a cookie.
        /// </summary>
        /// <param name="userName">The user name to sign in.</param>
        public void SignIn(string userName)
        {
            BeforeSignIn(userName);

            var authTicket = new FormsAuthenticationTicket(
                1,
                userName,
                TimeProvider.Current.Now,
                TimeProvider.Current.Now.AddMinutes(FormsAuthentication.Timeout.Minutes),
                false,
                "");

            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            HttpContext.Current.Response.Cookies.Add(cookie);

            AfterSignIn(userName);
        }

        /// <summary>
        /// Removes the session token.
        /// </summary>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// Perform additional actions before the user has been signed in.
        /// </summary>
        /// <param name="userName"></param>
        protected virtual void BeforeSignIn(string userName)
        {
            // Do nothing by default
        }

        /// <summary>
        /// Perform additional actions after the user has been signed in.
        /// </summary>
        /// <param name="userName"></param>
        protected virtual void AfterSignIn(string userName)
        {
            // Do nothing by default
        }
    }
}