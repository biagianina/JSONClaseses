using System;
using Xunit;

namespace Classes.Tests
{
    public class ChoiceTests
    {
        [Fact]
        public void ReturnsFalseForAnEmptyString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            Assert.False(digit.Match(""));
        }

        [Fact]
        public void ReturnsTrueForACorrectCharacterString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            Assert.True(digit.Match("012"));
        }

        [Fact]
        public void ReturnsTrueForACorrectRangeString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            Assert.True(digit.Match("12"));
        }

        [Fact]
        public void ReturnsFalseForAStringStartingWithLetter()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            Assert.False(digit.Match("a12"));
        }
    }
}
