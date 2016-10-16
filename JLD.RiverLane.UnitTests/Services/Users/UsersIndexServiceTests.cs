using AutoMapper;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Services.Users;
using Moq;
using System;
using Xunit;

namespace JLD.RiverLane.UnitTests.Services.Users
{
    public class UsersIndexServiceTests
    {
        private readonly RiverLaneContext dummyContext;
        private readonly IMapper dummyMapper;

        public UsersIndexServiceTests()
        {
            dummyContext = new Mock<RiverLaneContext>().Object;
            dummyMapper = new Mock<IMapper>().Object;
        }

        [Fact]
        public void Constructor_ContextIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersIndexService(null, dummyMapper));
        }

        [Fact]
        public void Constructor_MapperIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersIndexService(dummyContext, null));
        }
    }
}
