using System;
using System.Linq;
using BaseClasses.Fixtures;
using BaseClasses.Helpers;

namespace JLD.RiverLane.Models.Enums
{
    /// <summary>
    /// Contains extension methods for enums.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets a particular attribute from an enum value
        /// </summary>
        /// <typeparam name="TAttribute">The attribute to get</typeparam>
        /// <param name="value">The enum value to get the attribute from</param>
        public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            Check.NotNull(value, nameof(value));

            var type = value.GetType();
            var name = Enum.GetName(type, value);

            if (name == null)
            {
                return null;
            }

            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
    }
}
