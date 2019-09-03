using System;
using Xunit;

namespace Classes.Tests
{
    public class PhoneNumberTests
    {
        [Fact]
        public void ValidPrefixPhoneNumber()
        {
            var pattern = new PhoneNumber();
            Assert.True(pattern.Match("0743555555").Success());
            Assert.Empty(pattern.Match("0743555555").RemainingText());
        }


        [Fact]
        public void ValidPrefixPhoneNumberDashSeparator()
        {
            var pattern = new PhoneNumber();
            Assert.True(pattern.Match("0743-555555").Success());
            Assert.Empty(pattern.Match("0743-555555").RemainingText());
        }

        [Fact]
        public void ValidPrefixPhoneNumberDashAndPointSeparator()
        {
            var pattern = new PhoneNumber();
            Assert.True(pattern.Match("0743-555.555").Success());
            Assert.Empty(pattern.Match("0743-555.555").RemainingText());
        }

        [Fact]
        public void ValidCountryPrefixPhoneNumberDashAndPointSeparator()
        {
            var pattern = new PhoneNumber();
            Assert.True(pattern.Match("0040743555555").Success());
            Assert.Empty(pattern.Match("0040743555555").RemainingText());
        }

        [Fact]
        public void ValidCountryPlusPrefixPhoneNumberDashAndPointSeparator()
        {
            var pattern = new PhoneNumber();
            Assert.True(pattern.Match("+40743555555").Success());
            Assert.Empty(pattern.Match("+40743555555").RemainingText());
        }
    }
}
