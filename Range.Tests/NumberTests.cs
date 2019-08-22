using System;
using Xunit;

namespace Classes.Tests
{
    public class NumberTests
    {
        [Fact]
        public void ReturnsTrueAndEmptyForSingleDigit()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var zero = new Character('0');
            var naturalNumber = new Choice(zero, digits);
            var negative = new Optional(new Character('-'));
            var integerNumber = new Sequence(negative, naturalNumber);
            var fractional = new Optional(new Sequence(new Character('.'), digits));
            var exponential = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), digits));
            var pattern = new Sequence(integerNumber, fractional, exponential);
            Assert.True(pattern.Match("1").Succes());
            Assert.Equal("", pattern.Match("1").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForNumberStartingInZero()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var zero = new Character('0');
            var naturalNumber = new Choice(zero, digits);
            var negative = new Optional(new Character('-'));
            var integerNumber = new Sequence(negative, naturalNumber);
            var fractional = new Optional(new Sequence(new Character('.'), digits));
            var exponential = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), digits));
            var pattern = new Sequence(integerNumber, fractional, exponential);
            Assert.True(pattern.Match("0123").Succes());
            Assert.Equal("123", pattern.Match("0123").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForNegativeNumber()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var zero = new Character('0');
            var naturalNumber = new Choice(zero, digits);
            var negative = new Optional(new Character('-'));
            var integerNumber = new Sequence(negative, naturalNumber);
            var fractional = new Optional(new Sequence(new Character('.'), digits));
            var exponential = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), digits));
            var pattern = new Sequence(integerNumber, fractional, exponential);
            Assert.True(pattern.Match("-123").Succes());
            Assert.Equal("23", pattern.Match("-123").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForPositiveNumber()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var zero = new Character('0');
            var naturalNumber = new Choice(zero, digits);
            var negative = new Optional(new Character('-'));
            var integerNumber = new Sequence(negative, naturalNumber);
            var fractional = new Optional(new Sequence(new Character('.'), digits));
            var exponential = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), digits));
            var pattern = new Sequence(integerNumber, fractional,exponential);
            Assert.True(pattern.Match("123").Succes());
            Assert.Equal("23", pattern.Match("123").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForFractionalNumber()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var zero = new Character('0');
            var naturalNumber = new Choice(zero, digits);
            var negative = new Optional(new Character('-'));
            var integerNumber = new Sequence(negative, naturalNumber);
            var fractional = new Optional(new Sequence(new Character('.'), digits));
            var exponential = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), digits));
            var pattern = new Sequence(integerNumber, fractional, exponential);
            Assert.True(pattern.Match("1.12").Succes());
            Assert.Equal("", pattern.Match("1.12").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForSubunitaryNumber()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var zero = new Character('0');
            var naturalNumber = new Choice(zero, digits);
            var negative = new Optional(new Character('-'));
            var integerNumber = new Sequence(negative, naturalNumber);
            var fractional = new Optional(new Sequence(new Character('.'), digits));
            var exponential = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), digits));
            var pattern = new Sequence(integerNumber, fractional, exponential);
            Assert.True(pattern.Match("0.12").Succes());
            Assert.Equal("", pattern.Match("0.12").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForNumberEndingInPoint()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var zero = new Character('0');
            var naturalNumber = new Choice(zero, digits);
            var negative = new Optional(new Character('-'));
            var integerNumber = new Sequence(negative, naturalNumber);
            var fractional = new Optional(new Sequence(new Character('.'), digits));
            var exponential = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), digits));
            var pattern = new Sequence(integerNumber, fractional, exponential);
            Assert.True(pattern.Match("2.").Succes());
            Assert.Equal(".", pattern.Match("2.").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForExponentialNumber()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var zero = new Character('0');
            var naturalNumber = new Choice(zero, digits);
            var negative = new Optional(new Character('-'));
            var integerNumber = new Sequence(negative, naturalNumber);
            var fractional = new Optional(new Sequence(new Character('.'), digits));
            var exponential = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), digits));
            var pattern = new Sequence(integerNumber, fractional, exponential);
            Assert.True(pattern.Match("1.1E+3").Succes());
            Assert.Equal("", pattern.Match("1.1E+3").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForExponentialIncorrectNumber()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var zero = new Character('0');
            var naturalNumber = new Choice(zero, digits);
            var negative = new Optional(new Character('-'));
            var integerNumber = new Sequence(negative, naturalNumber);
            var fractional = new Optional(new Sequence(new Character('.'), digits));
            var exponential = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), digits));
            var pattern = new Sequence(integerNumber, fractional, exponential);
            Assert.True(pattern.Match("1.1E").Succes());
            Assert.Equal("E", pattern.Match("1.1E").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForExponentialWithoutSignNumber()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var zero = new Character('0');
            var naturalNumber = new Choice(zero, digits);
            var negative = new Optional(new Character('-'));
            var integerNumber = new Sequence(negative, naturalNumber);
            var fractional = new Optional(new Sequence(new Character('.'), digits));
            var exponential = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), digits));
            var pattern = new Sequence(integerNumber, fractional, exponential);
            Assert.True(pattern.Match("1.1e3").Succes());
            Assert.Equal("", pattern.Match("1.1e3").RemainingText());
        }

    }
}
