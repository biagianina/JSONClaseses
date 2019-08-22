using System;
using Xunit;

namespace Classes.Tests
{
    public class ManyTests
    {
        [Fact]
        public void ReturnsFalseAndEmptyForEmptyString()
        {
            var a = new Many(
                new Character('a'));
            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void ReturnsTrueEndTextForOneMatch()
        {
            var a = new Many(
                new Character('a'));
            Assert.True(a.Match("abc").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void ReturnsTrueEndTextForMultipleMatches()
        {
            var a = new Many(
                new Character('a'));
            Assert.True(a.Match("aaaabc").Success());
            Assert.Equal("bc", a.Match("aaaabc").RemainingText());
        }

        [Fact]
        public void ReturnsTrueEndTextForNoMatches()
        {
            var a = new Many(
                new Character('a'));
            Assert.True(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForMatches()
        {
            var digits = new Many(new Range('0', '9')); 
            Assert.True(digits.Match("12345ab123").Success());
            Assert.Equal("ab123", digits.Match("12345ab123").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndTextForNoMatchesRange()
        {
            var digits = new Many(new Range('0', '9'));
            Assert.True(digits.Match("ab").Success());
            Assert.Equal("ab", digits.Match("ab").RemainingText());
        }
    }
}