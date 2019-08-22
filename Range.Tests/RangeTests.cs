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
            Assert.False(digit.Match("").Success());
            Assert.Equal("", digit.Match("").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForCorrectString()
        {
            var digit = new Range('a', 'f');
            Assert.True(digit.Match("abc").Success());
            Assert.Equal("bc", digit.Match("abc").RemainingText());
        }

        [Fact]
        public void ReturnsFalseForStringStartingWithIncorrectChar()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match("1bc").Success());
            Assert.Equal("1bc", digit.Match("1bc").RemainingText());
        }
    }
}
