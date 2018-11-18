using JLD.RiverLane.Models;
using Moq;
using Moq.Language.Flow;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BaseClasses.Models;

namespace JLD.RiverLane.UnitTests
{
    /// <summary>
    /// Provides extension methods to simplify building mocks in common scenarios.
    /// </summary>
    public static class MoqExtensions
    {
        /// <summary>
        /// Specifies the items to return from a DbSet property on a mocked DbContext.
        /// </summary>
        /// <typeparam name="TContext">The DbContext being mocked. </typeparam>
        /// <typeparam name="TEntity">The type of entity to return.</typeparam>
        /// <param name="setup">An ISetup instance specifying the property to mock.</param>
        /// <param name="data">The items to return from the property.</param>
        public static IReturnsResult<TContext> ReturnsList<TContext, TEntity>(this ISetup<TContext, DbSet<TEntity>> setup, IEnumerable<TEntity> data)
            where TEntity : Entity
            where TContext : DbContext
        {
            var queryable = data.AsQueryable();
            var mockSet = new Mock<DbSet<TEntity>>();

            mockSet.As<IQueryable<TEntity>>().Setup(x => x.GetEnumerator()).Returns(queryable.GetEnumerator());
            mockSet.As<IQueryable<TEntity>>().Setup(x => x.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<TEntity>>().Setup(x => x.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<TEntity>>().Setup(x => x.Expression).Returns(queryable.Expression);
            mockSet.Setup(x => x.Include(It.IsAny<string>())).Returns(mockSet.Object);

            return setup.Returns(mockSet.Object);
        }
    }
}
