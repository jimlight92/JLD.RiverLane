using JLD.RiverLane.Models;
using System.Security.Principal;

namespace JLD.RiverLane.Security
{
    public class RiverLanePrincipal : IPrincipal
    {
        private readonly IIdentity identity;

        /// <summary>
        /// Initialises a new instance of the <see cref="RiverLanePrincipal"/> class.
        /// </summary>
        /// <param name="user">The user account which the principal represents.</param>
        public RiverLanePrincipal(UserAccount user) : this(new RiverLaneIdentity(user))
        {
        }

        /// <summary>
        /// Initialises a new instances of the <see cref="RiverLanePrincipal"/> class with the specified details.
        /// </summary>
        /// <param name="identity">The identity of the user.</param>
        public RiverLanePrincipal(RiverLaneIdentity identity)
        {
            Check.NotNull(identity, nameof(identity));
            this.identity = identity;
        }

        public IIdentity Identity
        {
            get
            {
                return identity;
            }
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}