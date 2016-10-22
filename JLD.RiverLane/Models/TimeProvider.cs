using System;
using System.Threading;

namespace JLD.RiverLane.Models
{
    /// <summary>
    /// An abstraction which provides the current time.  
    /// </summary>
    public abstract class TimeProvider
    {
        private static ThreadLocal<TimeProvider> current = new ThreadLocal<TimeProvider>(() => new SystemTimeProvider());

        /// <summary>
        /// Gets the current date and time in local time.
        /// </summary>
        public abstract DateTime Now { get; }

        /// <summary>
        /// Gets the current TimeProvider instance.
        /// </summary>
        public static TimeProvider Current
        {
            get { return current.Value; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                current.Value = value;
            }
        }

        /// <summary>
        /// Resets the current TimeProvider to use the system clock.
        /// </summary>
        public static void Reset()
        {
            TimeProvider.Current = new SystemTimeProvider();
        }
    }

}