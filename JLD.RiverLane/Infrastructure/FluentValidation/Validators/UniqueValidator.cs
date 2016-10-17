using FluentValidation.Validators;
using JLD.RiverLane.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace JLD.RiverLane.Infrastructure.FluentValidation.Validators
{
    /// <summary>
    /// Checks whether the specified property already exists in the database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UniqueValidator<T> : PropertyValidator
        where T : Entity
    {
        private readonly DbSet<T> dbSet;
        private Expression<Func<T, string>> propertySelector;
        private PropertyInfo idPropInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueValidator{T}"/> class. 
        /// </summary>
        /// <param name="dbSet">The set of <see cref="T"/> that the property cannot exist in.</param>
        /// <param name="propertySelector">The property of <see cref="T"/> that will be checked against.</param>
        /// <param name="whereClause">Checks input against only the entities returned by this function</param>
        public UniqueValidator(DbSet<T> dbSet, Expression<Func<T, string>> propertySelector, PropertyInfo idPropInfo) : base("{PropertyName} must be unique.")
        {
            this.dbSet = dbSet;
            this.propertySelector = propertySelector;
            this.idPropInfo = idPropInfo;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (idPropInfo != null)
            {
                var modelId = (int)idPropInfo.GetValue(context.Instance);
                return !dbSet.Where(x => x.Id != modelId).Select(propertySelector).Any(x => x.ToUpper() == ((string)context.PropertyValue).ToUpper());
            }

            return !dbSet.Select(propertySelector).Any(x => x.ToUpper() == ((string)context.PropertyValue).ToUpper());
        }
    }
}