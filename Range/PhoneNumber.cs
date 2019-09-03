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
            var countryPrefix = new Choice(
                new Sequence(
                    new Character('0'),
                    new Character('0'),
                    new Range('1', '9'),
                    new Range('0', '9')
                    ),
                new Sequence(
                    new Character('+'),
                    new Range('1', '9'),
                    new Range('0', '9')
                    ));

            var prefix = new Sequence(
                new Choice(
                    countryPrefix,
                    new Character('0')),
                new Sequence(
                    new Range('1', '9'),
                    new Range('1', '9'),
                    new Range('1', '9')));

            var number = new Sequence(prefix,
                new Optional(new Character('-')),
                new Sequence(new Sequence(
                    new Range('1', '9'),
                    new Range('1', '9'),
                    new Range('1', '9'),
                    new Optional(new Character('.')),
                    new Sequence(
                    new Range('1', '9'),
                    new Range('1', '9'),
                    new Range('1', '9'))
                        )
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
