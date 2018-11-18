using JLD.RiverLane.Services;
using JLD.RiverLane.Services.Home;
using JLD.RiverLane.ViewModels.Home;
using JLD.RiverLane.ViewModels.Shared;
using Moq;
using Xunit;

namespace JLD.RiverLane.UnitTests.Home
{
    public class HomeIndexServiceTests 
    {
        [Fact]
        public void Get_Called_ResolvesCorrectSlides()
        {
            // Arrange
            var mockSlideshowResolver = new Mock<ISlideshowResolver>();
            var sut = new HomeIndexService(mockSlideshowResolver.Object);

            // Act
            sut.Get();

            // Assert
            mockSlideshowResolver.Verify(a => a.Resolve(It.IsAny<HomeIndexModel>(), SlideshowGroupType.Main), Times.Once);
        }
    }
}
