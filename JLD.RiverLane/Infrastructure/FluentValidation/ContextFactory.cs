using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Models;
using System;

namespace JLD.RiverLane.Infrastructure.FluentValidation
{
    /// <summary>
    /// Contains a factory that can create a <see cref="RiverLaneContext"/> 
    /// </summary>
    public class ContextFactory : IContextFactory
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the ContextFactory class, used to inject the context into FluentValidation Validators
        /// </summary>
        /// <param name="connectionString">The connection string to the database</param>
        public ContextFactory(string connectionString)
        {
            Check.NotNullOrEmpty(connectionString, nameof(connectionString));
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Creates a <see cref="RiverLaneContext"/> 
        /// </summary>
        /// <returns></returns>
        public RiverLaneContext CreateContext()
        {
            return new RiverLaneContext();
        }
    }
}