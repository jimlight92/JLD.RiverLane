using FluentValidation;
using JLD.RiverLane.Infrastructure.FluentValidation.Validators;
using System;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Reflection;
using BaseClasses.Fixtures;
using BaseClasses.Models;

namespace JLD.RiverLane.Infrastructure.FluentValidation
{

    /// <summary>
    /// Contains custom validators to be used with the FluentValidation framework
    /// </summary>
    public static class CustomValidatorExtensions
    {
        /// <summary>
        /// Checks whether the property already exists within the given DbSet, compared to the given property of the Entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TEntity">The type of entity to check.</typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="dbSet">The list of existing entities.</param>
        /// <param name="propertySelector">The property to check against.</param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> Unique<T, TEntity>(this IRuleBuilder<T, string> ruleBuilder, DbSet<TEntity> dbSet, Expression<Func<TEntity, string>> propertySelector)
            where TEntity : Entity
        {
            return ruleBuilder.SetValidator(new UniqueValidator<TEntity>(dbSet, propertySelector, null));
        }

        /// <summary>
        /// Checks whether the property already exists within the given DbSet where the id is not equal to the given id Selector, compared to the given property of the Entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TEntity">The type of entity to check.</typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="dbSet">The list of existing entities.</param>
        /// <param name="propertySelector">The property to check against.</param>
        /// <param name="modelIdSelector">The id selector of the entity to ignore.</param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> Unique<T, TEntity>(this IRuleBuilder<T, string> ruleBuilder, DbSet<TEntity> dbSet, Expression<Func<TEntity, string>> propertySelector, Expression<Func<T, int>> modelIdSelector)
            where TEntity : Entity
        {
            Check.NotNull(dbSet, nameof(dbSet));
            Check.NotNull(propertySelector, nameof(propertySelector));

            PropertyInfo propInfo = null;
            if (modelIdSelector != null)
            {
                var member = modelIdSelector.Body as MemberExpression;
                propInfo = member.Member as PropertyInfo;
            }

            return ruleBuilder.SetValidator(new UniqueValidator<TEntity>(dbSet, propertySelector, propInfo));
        }
    }
}