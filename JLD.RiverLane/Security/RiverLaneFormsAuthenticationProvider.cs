using BaseClasses.Fixtures;
using BaseClasses.Helpers;
using BaseClasses.Models;
using BaseClasses.Security;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.Security
{
    /// <summary>
    /// Provides methods for validating User credentials
    /// </summary>
    public class RiverLaneFormsAuthenticationProvider : FormsAuthenticationProvider
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="RiverLaneFormsAuthenticationProvider"/> class
        /// </summary>
        /// <param name="context">A connection to the database</param>
        public RiverLaneFormsAuthenticationProvider(RiverLaneContext context)
        {
            Check.NotNull(context, nameof(context));
            this.context = context;

        }

        private RiverLaneContext context { get; }

        protected override AuthenticationResult GetAuthenticationResult(UserAccount user)
        {
            if (user == null)
            {
                return AuthenticationResult.InvalidCredentials;
            }

            return AuthenticationResult.Success;
        }

        protected override UserAccount GetUser(string userName)
        {
            return context.Users.FindUser(userName);
        }
    }
}