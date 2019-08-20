using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Match : IMatch 
    {
        readonly bool success;
        readonly string text;

        public Match(bool success, string text)
        {
            this.success = success;
            this.text = text;
        }

        public bool Succes()
        {
            return success;
        }

        public string RemainingText()
        {
            return text;
        }
    }
}
