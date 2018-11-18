using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using BaseClasses.Models;
using JLD.RiverLane.Models;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Infrastructure.FluentValidation;

namespace JLD.RiverLane.UnitTests
{
    [Xunit.Trait("Validator Test", "Validator")]
    public abstract class ValidatorTest<TValidator>
        where TValidator : IValidator
    {
        protected abstract TValidator Validator { get; }

        /// <summary>
        /// Returns an empty mock of <see cref="RiverLaneContext"/> 
        /// </summary>
        /// <returns></returns>
        protected RiverLaneContext MockContext()
        {
            return new Mock<RiverLaneContext>().Object;
        }

        /// <summary>
        /// Returns a mock context factory that returns an empty context 
        /// </summary>
        /// <returns></returns>
        protected Mock<IContextFactory> CreateFactory()
        {
            var mockContext = new Mock<RiverLaneContext>();
            return Factory(mockContext);
        }

        private static Mock<IContextFactory> Factory(Mock<RiverLaneContext> mockContext)
        {
            var mockFactory = new Mock<IContextFactory>();
            mockFactory.Setup(x => x.CreateContext())
                .Returns(mockContext.Object);

            return mockFactory;
        }

        /// <summary>
        /// Returns a mock context factory that creates a fake DbSet 
        /// </summary>
        /// <typeparam name="TEntity">The type of entity in the DbSet</typeparam>
        /// <param name="selector">Selects the DbSet from the <see cref="RipaContext"/></param>
        /// <returns></returns>
        protected Mock<IContextFactory> CreateFactory<TEntity>(Expression<Func<RiverLaneContext, DbSet<TEntity>>> selector)
            where TEntity : Entity
        {
            return CreateFactory(selector, new List<TEntity>());
        }

        /// <summary>
        /// Returns a mock context factory that creates a fake DbSet that returns a specified list of items
        /// </summary>
        /// <typeparam name="TEntity">The type of entity in the DbSet</typeparam>
        /// <param name="selector">Selects the DbSet from the <see cref="RipaContext"/></param>
        /// <param name="returnList">The list of entities to return</param>
        /// <returns></returns>
        protected Mock<IContextFactory> CreateFactory<TEntity>(Expression<Func<RiverLaneContext, DbSet<TEntity>>> selector, List<TEntity> returnList)
            where TEntity : Entity
        {
            var mockContext = new Mock<RiverLaneContext>();
            mockContext.Setup(selector).ReturnsList(returnList);
            return Factory(mockContext);
        }

        protected TModel ModelWithProperty<TModel>(Action<TModel> setter)
        {
            var model = Activator.CreateInstance<TModel>();
            setter(model);
            return model;
        }
    }
}
