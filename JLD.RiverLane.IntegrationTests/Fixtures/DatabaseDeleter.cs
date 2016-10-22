using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Models;
using System.Data.Entity;

namespace JLD.RiverLane.IntegrationTests.Fixtures
{
    /// <summary>
    /// Contains code for deleting entities in <see cref="RiverLaneContext"/> 
    /// </summary>
    public class DatabaseDeleter : IDatabaseDeleter<RiverLaneContext>
    {
        /// <summary>
        /// Removes all specified entities in <see cref="RiverLaneContext"/> 
        /// </summary>
        /// <param name="context"></param>
        public void DeleteAll(RiverLaneContext context)
        {
            DeleteAll<UserAccount>(context);
            DeleteAll<Settings>(context);
            DeleteAll<Address>(context);

            context.SaveChanges();
        }

        private void DeleteAll<TEntity>(RiverLaneContext context)
            where TEntity : Entity
        {
            foreach(var entity in context.Set<TEntity>())
            {
                context.Entry(entity).State = EntityState.Deleted;
            }
        }
    }
}
