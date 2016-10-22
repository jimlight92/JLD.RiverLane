using System.Security.Principal;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.Security
{
    public class RiverLaneIdentity : IIdentity
    {
        private readonly string name;
        private readonly int userId;

        public RiverLaneIdentity(UserAccount user)
        {
            Check.NotNull(user, nameof(user));
            name = user.Username;
            userId = user.Id;
        }

        /// <summary>
        /// Gets the authentication type used to authenticate the user.
        /// </summary>
        public string AuthenticationType
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// Gets a value indicating whether the user is authenticated.
        /// </summary>
        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Gets the id of the user.
        /// </summary>
        public int UserId
        {
            get
            {
                return userId;
            }
        }
    }
}