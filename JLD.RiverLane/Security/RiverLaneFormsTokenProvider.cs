﻿using System.Security.Principal;
using BaseClasses.Fixtures;
using BaseClasses.Helpers;
using BaseClasses.Models;
using BaseClasses.Security;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.Security
{
    /// <summary>
    /// Provides methods for creating a token for the user's session
    /// </summary>
    public class RiverLaneFormsTokenProvider : FormsAuthenticationTokenProvider
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="RiverLaneFormsTokenProvider"/> class
        /// </summary>
        /// <param name="context">A connection to the database</param>
        public RiverLaneFormsTokenProvider(RiverLaneContext context)
        {
            Check.NotNull(context, nameof(context));
            this.context = context;
        }

        private RiverLaneContext context { get; }

        protected override IPrincipal GetPrincipalFromUserAccount(UserAccount userAccount)
        {
            Check.NotNull(userAccount, nameof(userAccount));

            return new JLDPrincipal(userAccount);
        }

        protected override UserAccount GetUserAccount(string userName)
        {
            return context.Users.FindUser(userName);
        }
    }
}