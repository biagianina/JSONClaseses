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
                var match = pattern.Match(text);
                if (!match.Succes())
                {
                    return new Match(false, originalText);
                }

                text = match.RemainingText();
            }

            return new Match(true, text);
        }
    }
}
