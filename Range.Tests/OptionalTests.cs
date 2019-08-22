using System;
using Xunit;

namespace Classes.Tests
{
    public class OptionalTests
    {
        [Fact]
        public void ReturnsTrueAndEmptyForEmptyString()
        {
            var a = new Optional(
                new Character('a'));
            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRestForOneMatchString()
        {
            var a = new Optional(
                new Character('a'));
            Assert.True(a.Match("abc").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRestForTWoMatchString()
        {
            var a = new Optional(
                new Character('a'));
            Assert.True(a.Match("aabc").Success());
            Assert.Equal("abc", a.Match("aabc").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRestForSignMatchString()
        {
            var sign = new Optional(
                new Character('-'));
            Assert.True(sign.Match("-123").Success());
            Assert.Equal("123", sign.Match("-123").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndTextForSignNoMatchString()
        {
            var sign = new Optional(
                new Character('-'));
            Assert.True(sign.Match("123").Success());
            Assert.Equal("123", sign.Match("123").RemainingText());
        }
    }
}
