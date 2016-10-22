using System;
using Xunit;

namespace JLD.RiverLane.Models.Tests
{
    public class TimeProviderTests
    {
        [Fact]
        public void SetCurrent_ValueIsNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => TimeProvider.Current = null);
        }

        [Fact]
        public void SetCurrent_ValueIsNotNull_SetsProperty()
        {
            var expected = new TestTimeProvider();

            TimeProvider.Current = expected;

            Assert.Equal(expected, TimeProvider.Current);
        }

        [Fact]
        public void Reset_SetsCurrentProviderToSystemTime()
        {
            var stub = new TestTimeProvider();
            TimeProvider.Current = stub;

            TimeProvider.Reset();

            Assert.IsNotType<TestTimeProvider>(TimeProvider.Current);
        }

        private class TestTimeProvider : TimeProvider
        {
            public override DateTime Now
            {
                get { return DateTime.Now; }
            }
        }
    }
}
