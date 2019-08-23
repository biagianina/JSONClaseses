using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Value 
    {
        readonly IPattern pattern;

        public Value()
        {
            var value = new Choice(
             new String(),
             new Number(),
             new Text("true"),
             new Text("false"),
             new Text("null")
            );

            var whitespaces = new Many(new Any(" \n\r\t"));

            var validValue = new Sequence(whitespaces, value, whitespaces);

            var arrayValue = new List(validValue, new Character(','));

            var objectValue = new Sequence(new String(), whitespaces, new Character(':'), validValue);

            var array = new Sequence(
                whitespaces,
                new Character('['),
                whitespaces,
                arrayValue,
                whitespaces,
                new Character(']'),
                whitespaces
                );

           value.Add(array);

           var objects = new Sequence(
               whitespaces,
               new Character('{'),
               whitespaces,
               new List(objectValue, new Sequence(new Character(','), whitespaces)),
               whitespaces,
               new Character('}'),
               whitespaces);

            value.Add(objects);

            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
     
    }
}
