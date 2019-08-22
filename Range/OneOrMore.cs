using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class OneOrMore : IPattern
    {
        readonly IPattern pattern;
        readonly Many many;

        public OneOrMore(IPattern pattern)
        {
            this.many = new Many(pattern);
            this.pattern = new Sequence(pattern, many);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
