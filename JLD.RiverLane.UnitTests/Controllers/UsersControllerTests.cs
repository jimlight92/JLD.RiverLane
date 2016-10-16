using JLD.RiverLane.Controllers;
using System;
using Xunit;

namespace JLD.RiverLane.UnitTests.Controllers
{
    public class UsersControllerTests
    {
        [Fact]
        public void Constructor_ServiceIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersController(null));
        }
    }
}
