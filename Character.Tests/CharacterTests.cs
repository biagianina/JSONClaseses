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
            Assert.False(pattern.Match(""));
        }

        [Fact]
        public void ReturnsTrueForCorrectString()
        {
            var pattern = new Character('a');
            Assert.True(pattern.Match("abc"));
        }

        [Fact]
        public void ReturnsFalseForCorrectString()
        {
            var pattern = new Character('a');
            Assert.False(pattern.Match("bac"));
        }
    }
}
