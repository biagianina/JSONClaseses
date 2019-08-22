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
            this.separator = separator;
            this.many = new Many(new Sequence(separator, pattern));
            this.pattern = new Many(new Sequence(pattern, many));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
