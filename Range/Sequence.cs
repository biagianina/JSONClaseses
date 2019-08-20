using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Sequence : IPattern
    {
        readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            string originalText = text;
            foreach (var pattern in patterns)
            {
                if (pattern.Match(text).Succes())
                {
                    text = pattern.Match(text).RemainingText();
                }
                else
                {
                    return new Match(false, originalText);
                }
            }

            return new Match(true, text);
        }
    }
}
