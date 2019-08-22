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
            Assert.False(digit.Match("").Success());
            Assert.Equal("", digit.Match("").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForACorrectCharacterString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            Assert.True(digit.Match("012").Success());
            Assert.Equal("12", digit.Match("012").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForA()
        {
            var digit = new Choice(
                new Many(new Character('1'))
                );
            Assert.True(digit.Match("112").Success());
            Assert.Equal("2", digit.Match("112").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForACorrectRangeString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            Assert.True(digit.Match("12").Success());
            Assert.Equal("2", digit.Match("12").RemainingText());
        }

        [Fact]
        public void ReturnsFalseForAStringStartingWithLetter()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            Assert.False(digit.Match("a12").Success());
            Assert.Equal("a12", digit.Match("a12").RemainingText());
        }

        [Fact]
        public void ReturnsFalseForAStringContainingIncorrectUNICODE()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                    )
                  );
            Assert.False(hex.Match("G12").Success());
            Assert.Equal("G01", hex.Match("G01").RemainingText());
        }
    }
}
