using System;
using Xunit;

namespace Classes.Tests
{
    public class OneOrMoreTests
    {
        [Fact]
        public void ReturnsFalseAndEmptyForEmptyString()
        {
            var a = new OneOrMore(
                new Range('0', '9'));
            Assert.False(a.Match("").Succes());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndEmptyForThreeMatchesString()
        {
            var a = new OneOrMore(
                new Range('0', '9'));
            Assert.True(a.Match("123").Succes());
            Assert.Equal("", a.Match("123").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForTwoMatchesString()
        {
            var a = new OneOrMore(
                new Range('0', '9'));
            Assert.True(a.Match("12a").Succes());
            Assert.Equal("a", a.Match("12a").RemainingText());
        }

        [Fact]
        public void ReturnsFalseAndTextForNoMatchesString()
        {
            var a = new OneOrMore(
                new Range('0', '9'));
            Assert.False(a.Match("bc").Succes());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }


    }
}
