using System;
using Xunit;

namespace Classes.Tests
{
    public class NumberTests
    {
        [Fact]
        public void ReturnsTrueAndEmptyForSingleDigit()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("1").Success());
            Assert.Equal("", pattern.Match("1").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForNumberStartingInZero()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("0123").Success());
            Assert.Equal("123", pattern.Match("0123").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForNegativeNumber()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("-123").Success());
            Assert.Equal("", pattern.Match("-123").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForPositiveNumber()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("123").Success());
            Assert.Equal("", pattern.Match("123").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForFractionalNumber()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("1.12").Success());
            Assert.Equal("", pattern.Match("1.12").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForSubunitaryNumber()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("123.12").Success());
            Assert.Equal("", pattern.Match("123.12").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForIntegerNumber()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("12").Success());
            Assert.Equal("", pattern.Match("12").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForNumberEndingInPoint()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("2.").Success());
            Assert.Equal(".", pattern.Match("2.").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForExponentialNumber()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("1.1E+3").Success());
            Assert.Equal("", pattern.Match("1.1E+3").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForExponentialIncorrectNumber()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("1.1E").Success());
            Assert.Equal("E", pattern.Match("1.1E").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForExponentialWithoutSignNumber()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("1.1e3").Success());
            Assert.Equal("", pattern.Match("1.1e3").RemainingText());
        }

    }
}
