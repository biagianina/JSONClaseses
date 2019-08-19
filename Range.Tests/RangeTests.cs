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
            Assert.False(digit.Match(""));
        }

        [Fact]
        public void ReturnsTrueForCorrectString()
        {
            var digit = new Range('a', 'f');
            Assert.True(digit.Match("abc"));
        }

        [Fact]
        public void ReturnsFalseForStringStartingWithIncorrectChar()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match("1bc"));
        }
    }
}
