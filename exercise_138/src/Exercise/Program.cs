using System;
using System.Collections.Generic;

namespace Exercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("matthew", "matt");
            dict.Add("michael", "mix");
            dict.Add("arthur", "artie");

            foreach(KeyValuePair<string, string> entry in dict)
            {
                Console.WriteLine($"{entry.Key}'s nickname is {entry.Value}");
            }
        }
    }
}