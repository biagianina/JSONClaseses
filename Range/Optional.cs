using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Optional
    {
        IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = pattern.Match(text);

            if(match.Succes())
            {
                return new Match(true, match.RemainingText());
            }

            return new Match(true, text);
        }
    }
}
