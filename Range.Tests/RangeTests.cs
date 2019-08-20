using System;
using Xunit;

namespace Classes.Tests
{
    public class RangeTests
    {
        [Fact]
        public void ReturnsFalseForEmptyString()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match("").Succes());
            Assert.Equal("", digit.Match("").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForCorrectString()
        {
            var digit = new Range('a', 'f');
            Assert.True(digit.Match("abc").Succes());
            Assert.Equal("bc", digit.Match("abc").RemainingText());
        }

        [Fact]
        public void ReturnsFalseForStringStartingWithIncorrectChar()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match("1bc").Succes());
            Assert.Equal("1bc", digit.Match("1bc").RemainingText());
        }
    }
}
