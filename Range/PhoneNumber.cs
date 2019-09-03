using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class PhoneNumber : IPattern
    {
        readonly IPattern pattern;
        
        public PhoneNumber()
        {
            var digit = new Range('0', '9');
            var zero = new Character('0');
            var threeDigits = new Sequence(
                    digit,
                    digit,
                    digit);

            var countryPrefix = new Choice(
                new Sequence(
                    zero, zero, digit, digit
                    ),
                new Sequence(
                    new Character('+'),
                    digit,
                    digit
                    ));

            var prefix = new Sequence(
                new Choice(
                    countryPrefix,
                    zero),
                threeDigits
                );

            var number = new Sequence(prefix,
                new Optional(new Character('-')),
                new Sequence(
                   threeDigits,
                    new Optional(new Character('.')),
                   threeDigits
                 )
                );

            pattern = number;
        }

        public IMatch Match(string phoneNumber)
        {
            return pattern.Match(phoneNumber);
        }
    }
}
