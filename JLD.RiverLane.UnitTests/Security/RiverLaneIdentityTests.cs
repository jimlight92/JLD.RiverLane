using JLD.RiverLane.Security;
using System;
using Xunit;

namespace JLD.RiverLane.UnitTests.Security
{
    public class RiverLaneIdentityTests
    {
        [Fact]
        public void Constructor_UserIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new RiverLaneIdentity(null));
        }
    }
}
