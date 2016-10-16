using System.Data.Entity;

namespace JLD.RiverLane.IntegrationTests.Fixtures
{
    /// <summary>
    /// Contains a method for deleting all data in a database
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IDatabaseDeleter<TContext>
        where TContext : DbContext
    {
        /// <summary>
        /// Removes all data in the specified context
        /// </summary>
        /// <param name="context"></param>
        void DeleteAll(TContext context);
    }
}