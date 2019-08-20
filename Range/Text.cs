using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Text
    {
        readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            int stop = prefix.Length;
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            if(text.Substring(0, stop) == prefix)
            {
                return new Match(true, text.Substring(stop));
            }

            return new Match(false, text);
        }
    }
}
