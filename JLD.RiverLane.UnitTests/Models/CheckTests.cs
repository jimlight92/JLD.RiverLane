using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace JLD.RiverLane.Models.Tests
{
    public class CheckTests
    {
        [Fact]
        public void NotNull_ValueIsNull_Throws()
        {
            Assert.Throws<ArgumentNullException>("param", () => Check.NotNull(null, "param"));
        }

        [Fact]
        public void NotNull_ValueIsNotNull_DoesNotThrow()
        {
            Check.NotNull("notnull", "test");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NotNullOrEmpty_ValueIsNullOrEmpty_Throws(string value)
        {
            Assert.Throws<ArgumentNullException>("param", () => Check.NotNullOrEmpty(value, "param"));
        }

        [Fact]
        public void NotNullOrEmpty_ValueNotNullOrEmpty_DoesNotThrow()
        {
            Check.NotNullOrEmpty("notempty", "param");
        }

        [Fact]
        public void NotMinValue_ValueIsDateMinValue_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>("param", () => Check.NotMinValue(DateTime.MinValue, "param"));
        }

        [Fact]
        public void NotMinValue_ValueIsNotDateMinValue_DoesNotThrow()
        {
            Check.NotMinValue(new DateTime(2000, 01, 01), "param");
        }

        [Fact]
        public void NotNullOrEmpty_ValueIsNullEnumerable_Throws()
        {
            IEnumerable<string> enumerable = null;
            Assert.Throws<ArgumentNullException>("param", () => Check.NotNullOrEmpty(enumerable, "param"));
        }

        [Fact]
        public void NotNullOrEmpty_ValueIsEmptyEnumerable_Throws()
        {
            IEnumerable<string> enumerable = new List<string>();
            Assert.Throws<ArgumentNullException>("param", () => Check.NotNullOrEmpty(enumerable, "param"));
        }

        [Fact]
        public void NotNullOrEmpty_ValueIsNotEmptyEnumerable_DoesNotThrow()
        {
            IEnumerable<string> enumerable = new List<string>() { "test" };
            Check.NotNullOrEmpty(enumerable, "param");
        }
    }
}
