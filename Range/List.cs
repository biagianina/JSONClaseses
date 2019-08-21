using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class List
    {
        readonly IPattern pattern;
        readonly IPattern separator;
        readonly Many many;

        public List(IPattern pattern, IPattern separator)
        {
            this.pattern = pattern;
            this.separator = separator;
            this.many = new Many(new Sequence(separator, pattern));
        }

        public IMatch Match(string text)
        {
            var match = pattern.Match(text);
            return !match.Succes() ? new Match(true, text) : many.Match(match.RemainingText());
        }
    }
}
