using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Number :IPattern
    {
        readonly IPattern pattern;

        public Number()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var zero = new Character('0');
            var naturalNumber = new Choice(zero, digits);
            var negative= new Optional(new Character('-'));
            var integerNumber = new Sequence(negative, naturalNumber);
            var fractional = new Optional(new Sequence(new Character('.'), digits));
            var exponential = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), digits));
            pattern = new Sequence (integerNumber, fractional, exponential);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
