using System;
using System.IO;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                foreach (Object obj in args)
                {
                    var text = File.ReadAllText(obj.ToString());
                    var json = new Value();
                    Console.WriteLine(json.Match(text).Success());
                    Console.WriteLine(json.Match(text).RemainingText());
                }
            }

            Console.Read();
        }
    }
}
