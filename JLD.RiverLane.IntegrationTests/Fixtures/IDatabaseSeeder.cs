using System.Data.Entity;

namespace JLD.RiverLane.IntegrationTests.Fixtures
{
    /// <summary>
    /// Contains a method for adding data to a database
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IDatabaseSeeder<TContext>
        where TContext : DbContext
    {
        /// <summary>
        /// Seeds the database with initial data
        /// </summary>
        /// <param name="context"></param>
        void Seed(TContext context);
    }
}
