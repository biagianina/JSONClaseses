using System;
using Xunit;

namespace Range.Tests
{
    public class RangeTests
    {
        [Fact]
        public void ReturnsNullForEmptyString()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match(""));
        }
    }
}
