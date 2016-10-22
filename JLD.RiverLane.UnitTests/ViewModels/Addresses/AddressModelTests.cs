using JLD.RiverLane.ViewModels.Addresses;
using Xunit;

namespace JLD.RiverLane.UnitTests.ViewModels.Addresses
{
    public class AddressModelTests : ValidatorTest<AddressModelValidator>
    {
        protected override AddressModelValidator Validator
        {
            get
            {
                return new AddressModelValidator(MockContext());
            }
        }

        [Fact]
        public void Validate_NoPropertiesSet_Fails()
        {
            // Arrange
            var model = new AddressModel();

            // Act
            var result = Validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_HouseNameSetAndLessThan50Chars_Passes()
        {
            // Arrange
            var model = ModelWithProperty<AddressModel>(x => x.HouseName = new string('a', 50));

            // Act
            var result = Validator.Validate(model);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_HouseNameSetAndMoreThan50Chars_Fails()
        {
            // Arrange
            var model = ModelWithProperty<AddressModel>(x => x.HouseName = new string('a', 51));

            // Act
            var result = Validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_StreetSetAndLessThan50Chars_Passes()
        {
            // Arrange
            var model = ModelWithProperty<AddressModel>(x => x.Street = new string('a', 50));

            // Act
            var result = Validator.Validate(model);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_StreetSetAndMoreThan50Chars_Fails()
        {
            // Arrange
            var model = ModelWithProperty<AddressModel>(x => x.Street = new string('a', 51));

            // Act
            var result = Validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_TownSetAndLessThan50Chars_Passes()
        {
            // Arrange
            var model = ModelWithProperty<AddressModel>(x => x.Town = new string('a', 50));

            // Act
            var result = Validator.Validate(model);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_TownSetAndMoreThan50Chars_Fails()
        {
            // Arrange
            var model = ModelWithProperty<AddressModel>(x => x.Town = new string('a', 51));

            // Act
            var result = Validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_CitySetAndLessThan50Chars_Passes()
        {
            // Arrange
            var model = ModelWithProperty<AddressModel>(x => x.City = new string('a', 50));

            // Act
            var result = Validator.Validate(model);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_CitySetAndMoreThan50Chars_Fails()
        {
            // Arrange
            var model = ModelWithProperty<AddressModel>(x => x.City = new string('a', 51));

            // Act
            var result = Validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_PostcodeSetAndLessThan10Chars_Passes()
        {
            // Arrange
            var model = ModelWithProperty<AddressModel>(x => x.Postcode = new string('a',10));

            // Act
            var result = Validator.Validate(model);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_PostcodeSetAndMoreThan10Chars_Fails()
        {
            // Arrange
            var model = ModelWithProperty<AddressModel>(x => x.Postcode = new string('a', 11));

            // Act
            var result = Validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}

