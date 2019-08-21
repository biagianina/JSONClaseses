using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class OneOrMore
    {
        readonly IPattern pattern;
        readonly Many many;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = pattern;
            this.many = new Many(pattern);
        }

        public IMatch Match(string text)
        {
            var match = pattern.Match(text);
            if(match.Succes())
            {
                return many.Match(match.RemainingText());
            }

            return new Match(false, text);
        }
    }
}
