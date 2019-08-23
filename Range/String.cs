using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class String : IPattern
    {
        readonly IPattern pattern;

        public String()
        {
            var quotation = new Character('"');

            var character = new Choice(
                new Range(' ', '!'),
                new Range('#', '.'),
                new Range('0', '['),
                new Range(']', (char)ushort.MaxValue)
                );

            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            var escapeCharacters = new Any("\"\\/bfnrt");

            var unicode = new Sequence(
                new Character('u'), 
                hex, 
                hex, 
                hex, 
                hex);

            var validEscapeCharacters = new Sequence(
                new Character('\\'), 
                new Choice(escapeCharacters, unicode));

            var text = new Many(
                    new Choice(
                        character,
                        validEscapeCharacters));
                        
            pattern = new Sequence(quotation, text, quotation);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
