using JLD.RiverLane.Services.Settings;
using JLD.RiverLane.ViewModels.Addresses;
using JLD.RiverLane.ViewModels.Settings;
using Xunit;

namespace JLD.RiverLane.IntegrationTests.Services.Settings
{
    public class SettingsEditServiceTests : DatabaseTest
    {
        [Fact]
        public void Get_CalledWithoutModel_ReturnsPopulatedViewModel()
        {
            // Arrange
            Context.Settings.ContactAddress.Town = "Town";
            Context.Settings.ChangeContactNumber("Number");
            Context.Settings.ChangeContactEmail("Email");

            Context.SaveChanges();

            var sut = GetSut();

            // Act
            var result = sut.Get();

            // Assert
            Assert.Equal("Town", result.Address.Town);
            Assert.Equal("Number", result.ContactNumber);
            Assert.Equal("Email", result.ContactEmail);
        }

        private SettingsEditService GetSut()
        {
            return new SettingsEditService(Context, Mapper);
        }

        [Fact]
        public void Get_CalledWithModel_ReturnsSameModel()
        {
            // Arrange
            var model = new SettingsEditModel()
            {
                ContactEmail = "Email"
            };

            var sut = GetSut();

            // Act
            var result = sut.Get(model);

            // Assert
            Assert.Equal("Email", model.ContactEmail);
        }

        [Fact]
        public void Post_Called_ChangesSettings()
        {
            // Arrange
            Context.Settings.ContactAddress.Town = "Original Town";
            Context.Settings.ChangeContactNumber("Original Number");
            Context.Settings.ChangeContactEmail("Original Email");

            Context.SaveChanges();

            var model = new SettingsEditModel()
            {
                ContactEmail = "New Email",
                ContactNumber = "New Number",
                Address = new AddressModel()
                {
                    Town = "New Town"
                }
            };

            var sut = GetSut();

            // Act
            var result = sut.Post(model);

            // Assert
            Assert.Equal("New Town", model.Address.Town);
            Assert.Equal("New Number", model.ContactNumber);
            Assert.Equal("New Email", model.ContactEmail);
        }
    }
}
