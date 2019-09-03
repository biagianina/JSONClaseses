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

                    if (string.IsNullOrEmpty(json.Match(text).RemainingText()))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine("Invalid");
                    }
                }
            }

            Console.Read();
        }
    }
}
