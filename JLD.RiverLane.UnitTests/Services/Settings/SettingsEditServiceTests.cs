using AutoMapper;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Services.Settings;
using Moq;
using System;
using Xunit;

namespace JLD.RiverLane.UnitTests.Services.Settings
{
    public class SettingsEditServiceTests
    {
        private readonly RiverLaneContext dummyContext;
        private readonly IMapper dummyMapper;

        public SettingsEditServiceTests()
        {
            dummyContext = new Mock<RiverLaneContext>().Object;
            dummyMapper = new Mock<IMapper>().Object;
        }

        [Fact]
        public void Constructor_ContextIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SettingsEditService(null, dummyMapper));
        }

        [Fact]
        public void Constructor_MapperIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SettingsEditService(dummyContext, null));
        }
    }
}
