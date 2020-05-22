using System;
using System.Collections.Generic;

namespace Exercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("f.e", "for example");
            dict.Add("etc.", "and so on");
            dict.Add("i.e", "more precisely");

            PrintKeys(dict);
            Console.WriteLine("---");
            PrintKeysWhere(dict, "i");
            Console.WriteLine("---");
            PrintValuesOfKeysWhere(dict, ".e");
        }

        public static void PrintKeys(Dictionary<string, string> dict)
        {
            foreach (KeyValuePair<string, string> entry in dict) {
                Console.WriteLine(entry.Key);
            }
        }

        public static void PrintKeysWhere(Dictionary<string, string> dict, string text)
        {
            foreach (KeyValuePair<string, string> entry in dict) {
                if (entry.Key.Contains(text)) {
                    Console.WriteLine(entry.Key);
                }
            }
        }

        public static void PrintValuesOfKeysWhere(Dictionary<string, string> dict, string text)
        {
            foreach (KeyValuePair<string, string> entry in dict) {
                if (entry.Key.Contains(text)) {
                    Console.WriteLine(entry.Value);
                }
            }
        }
    }
}

