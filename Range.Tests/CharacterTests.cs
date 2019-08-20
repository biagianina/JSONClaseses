using System;
using Xunit;

namespace Classes.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void ReturnsFalseForEmptyString()
        {
            var pattern = new Character('a');
            Assert.False(pattern.Match("").Succes());
            Assert.Equal("", pattern.Match("").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForCorrectString()
        {
            var pattern = new Character('a');
            Assert.True(pattern.Match("abc").Succes());
            Assert.Equal("bc", pattern.Match("abc").RemainingText());
        }

        [Fact]
        public void ReturnsFalseFoIncorrectString()
        {
            var pattern = new Character('a');
            Assert.False(pattern.Match("bac").Succes());
            Assert.Equal("bac", pattern.Match("bac").RemainingText());
        }
    }
}

