using System;
using Xunit;

namespace Classes.Tests
{
    public class TextTests
    {
        [Fact]
        public void ReturnsFalseAndEmptyForEmptyString()
        {
            var tr = new Text("true");
            Assert.False(tr.Match("").Success());
            Assert.Equal("", tr.Match("").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndEmptyForTrueString()
        {
            var tr = new Text("true");
            Assert.True(tr.Match("true").Success());
            Assert.Equal("", tr.Match("true").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndXForTrueandXString()
        {
            var tr = new Text("true");
            Assert.True(tr.Match("trueX").Success());
            Assert.Equal("X", tr.Match("trueX").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndTextForEmptyPrefix()
        {
            var empty = new Text("");
            Assert.True(empty.Match("true").Success());
            Assert.Equal("true", empty.Match("true").RemainingText());
        }
    }
}
