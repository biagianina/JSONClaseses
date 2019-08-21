using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Many 
    {
        readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = pattern.Match(text);

            if (!match.Succes())
            {
                return new Match(true, text);
            }
            else
            {
                while (match.Succes())
                {
                    match = pattern.Match(match.RemainingText());
                }
            }
            return new Match(true, match.RemainingText());
        }
    }
}
