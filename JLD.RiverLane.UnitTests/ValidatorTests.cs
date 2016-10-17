using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
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

            var mockFactory = new Mock<IContextFactory>();
            mockFactory.Setup(x => x.CreateContext())
                .Returns(mockContext.Object);

            return mockFactory;
        }

        protected TModel ModelWithProperty<TModel>(Action<TModel> setter)
        {
            var model = Activator.CreateInstance<TModel>();
            setter(model);
            return model;
        }
    }
}
