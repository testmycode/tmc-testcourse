using System;

namespace TestProject
{
    public class Program
    {
        public static bool ReturnTrue => true;

        public static bool ReturnNotInput(bool input)
        {
            return !input;
        }

        public static string ReturnInputString(string input)
        {
            return input;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Home");
        }
    }
}
