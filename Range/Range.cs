﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Range
{
    public class Range
    {
        readonly char start;
        readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            return true;
        }
    }
}
