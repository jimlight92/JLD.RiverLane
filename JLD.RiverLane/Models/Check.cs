using System;
using System.Collections.Generic;
using System.Linq;

namespace JLD.RiverLane.Models
{
    /// <summary>
    /// Contains code to validate input into functions
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the specified value is null or empty
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool NotNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name);
            }

            return true;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the specified object is null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool NotNull(object value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }

            return true;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the specified <see cref="DateTime"/> is null or equal to DateTime.MinValue
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool NotMinValue(DateTime value, string name)
        {
            if (value == DateTime.MinValue)
            {
                throw new ArgumentOutOfRangeException(name);
            }

            return true;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the specified not <see cref="IEnumerable"/> is null or empty
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool NotNullOrEmpty<T>(IEnumerable<T> value, string name)
        {
            if (value == null || !value.Any())
            {
                throw new ArgumentNullException(name);
            }

            return true;
        }
    }
}