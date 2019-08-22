using System;
using Xunit;

namespace Classes.Tests
{
    public class StringTests
    {
        [Fact]
        public void ReturnsTrueAndEmptyForOneCharacterString()
        {
            var pattern = new String();
            Assert.True(pattern.Match("\"a\"").Success());
            Assert.Equal("", pattern.Match("\"a\"").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndEmptyForQuotationEscapeCharacterString()
        {
            var pattern = new String();
            Assert.True(pattern.Match("\"\\\"\"").Success());
            Assert.Equal("", pattern.Match("\"\\\"\"").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndEmptyForBackslashEscapeCharacterString()
        {
            var pattern = new String();
            Assert.True(pattern.Match("\"\\\\\"").Success());
            Assert.Equal("", pattern.Match("\"\\\"\"").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndEmptyForBEscapeCharacterString()
        {
            var pattern = new String();
            Assert.True(pattern.Match("\"\\b\"").Success());
            Assert.Equal("", pattern.Match("\"\\b\"").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndEmptyForSlashEscapeCharacterString()
        {
            var pattern = new String();
            Assert.True(pattern.Match("\"\\/\"").Success());
            Assert.Equal("", pattern.Match("\"\\\"\"").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndEmptyForUnicodeString()
        {
            var pattern = new String();
            Assert.True(pattern.Match("\"\\u01Af\"").Success());
            Assert.Equal("", pattern.Match("\"\\u01Af\"").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndTextForIncorrectUnicodeString()
        {
            var pattern = new String();
            Assert.False(pattern.Match("\"\\u01A\"").Success());
            Assert.Equal("\"\\u01A\"", pattern.Match("\"\\u01A\"").RemainingText());
        }

        [Fact]
        public void ReturnsFalseAndTextForNotStartingInQuotationString()
        {
            var pattern = new String();
            Assert.False(pattern.Match("\\u01Af\"").Success());
            Assert.Equal("\\u01Af\"", pattern.Match("\\u01Af\"").RemainingText());
        }

        [Fact]
        public void ReturnsFalseAndTextForNotPreceededByEscapecharacterQuotationString()
        {
            var pattern = new String();
            Assert.False(pattern.Match("\"\"\"").Success());
            Assert.Equal("\"\"\"", pattern.Match("\"\"\"").RemainingText());
        }

        [Fact]
        public void ReturnsFalseAndTextForNotPreceededByEscapecharacterBackslashString()
        {
            var pattern = new String();
            Assert.False(pattern.Match("\"\\\"").Success());
            Assert.Equal("\"\\\"", pattern.Match("\"\\\"").RemainingText());
        }

        [Fact]
        public void ReturnsFalseAndTextForNotPreceededByEscapecharacterSlashString()
        {
            var pattern = new String();
            Assert.False(pattern.Match("\"/\"").Success());
            Assert.Equal("\"/\"", pattern.Match("\"/\"").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndEmptyForMultipleEscapecharactersString()
        {
            var pattern = new String();
            Assert.True(pattern.Match("\"ab\\/\\u0097\"").Success());
            Assert.Equal("", pattern.Match("\"ab\\/\\u0097\"").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndEmptyForComplexString()
        {
            var pattern = new String();
            Assert.True(pattern.Match("\"Test\\u0097\\nAnother line\"").Success());
            Assert.Equal("", pattern.Match("\"Test\\u0097\\nAnother line\"").RemainingText());
        }

    }
}
