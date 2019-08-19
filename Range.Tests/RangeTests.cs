using System;
using Xunit;

namespace Range.Tests
{
    public class RangeTests
    {
        [Fact]
        public void ReturnsFalseForEmptyString()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match(""));
        }

        [Fact]
        public void ReturnsTrueForCorrectString()
        {
            var digit = new Range('a', 'f');
            Assert.True(digit.Match("abc"));
        }
    }
}
