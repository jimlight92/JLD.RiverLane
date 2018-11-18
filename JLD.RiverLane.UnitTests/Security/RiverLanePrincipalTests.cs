using JLD.RiverLane.Security;
using System;
using BaseClasses.Models;
using Xunit;

namespace JLD.RiverLane.UnitTests.Security
{
    public class RiverLanePrincipalTests
    {
        [Fact]
        public void Constructor_IdentityIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new RiverLanePrincipal(null as RiverLaneIdentity));
        }

        [Fact]
        public void Constructor_UserIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new RiverLanePrincipal(null as UserAccount));
        }
    }
}
