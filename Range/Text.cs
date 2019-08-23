using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Text : IPattern
    {
        readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            return text.StartsWith(prefix) ? new Match(true, text.Substring(prefix.Length)) : new Match(false, text);
        }
    }
}
