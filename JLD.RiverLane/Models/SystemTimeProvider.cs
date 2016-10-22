using System;

namespace JLD.RiverLane.Models
{
    /// <summary>
    /// A time provider which returns the current time according to the system clock.
    /// </summary>
    public class SystemTimeProvider : TimeProvider
    {
        /// <summary>
        /// Gets the current date and time on this computer in local time.
        /// </summary>
        public override DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}