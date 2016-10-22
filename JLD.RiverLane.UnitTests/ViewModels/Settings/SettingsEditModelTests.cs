using FluentValidation.TestHelper;
using JLD.RiverLane.ViewModels.Settings;
using Xunit;

namespace JLD.RiverLane.UnitTests.ViewModels.Settings
{
    public class SettingsEditModelTests : ValidatorTest<SettingsEditModelValidator>
    {
        protected override SettingsEditModelValidator Validator
        {
            get
            {
                return new SettingsEditModelValidator(CreateFactory().Object);
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ContactNumber_NullOrEmpty_Fails(string number)
        {
            // Arrange & Act & Assert
            Validator.ShouldHaveValidationErrorFor(x => x.ContactNumber, number);
        }

        [Fact]
        public void ContactNumber_NotNullAndOver30Characters_Fails()
        {
            // Arrange & Act & Assert
            Validator.ShouldHaveValidationErrorFor(x => x.ContactNumber, new string('a', 31));
        }

        [Fact]
        public void ContactNumber_NotNullAnd30Characters_Passes()
        {
            // Arrange & Act & Assert
            Validator.ShouldNotHaveValidationErrorFor(x => x.ContactNumber, new string('a', 30));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ContactEmail_NullOrEmpty_Fails(string number)
        {
            // Arrange & Act & Assert
            Validator.ShouldHaveValidationErrorFor(x => x.ContactEmail, number);
        }

        [Fact]
        public void ContactEmail_NotNullAndOver200Characters_Fails()
        {
            // Arrange & Act & Assert
            Validator.ShouldHaveValidationErrorFor(x => x.ContactEmail, new string('a', 201));
        }

        [Fact]
        public void ContactEmail_NotNullAnd200Characters_Passes()
        {
            // Arrange & Act & Assert
            Validator.ShouldNotHaveValidationErrorFor(x => x.ContactEmail, new string('a', 200));
        }
    }
}
