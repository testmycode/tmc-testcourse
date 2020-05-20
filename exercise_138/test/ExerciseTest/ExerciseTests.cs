using System;
using System.IO;
using Xunit;
using Exercise;
using System.Text.RegularExpressions;

namespace ExerciseTest
{
    public class Tests /*: IDisposable*/
    {
        string target = "../../../";
        string current = Directory.GetCurrentDirectory();

        /*
        public Tests() {
            Directory.SetCurrentDirectory(target);
        }

        public void Dispose()
        {
            Directory.SetCurrentDirectory(current);
        }
        */

        [Fact]
        public void TestMainExists()
        {
            string code = File.ReadAllText("../../src/Exercise/Program.cs");
            int count = Regex.Matches(code, @"public static void Main\(string\[\] args\)").Count;

            Assert.Equal(1, count/*, "Do not destroy the Main class from Program.cs!"*/);
        }

        [Fact]
        public void TestDictionaryIsUsed()
        {
            string code = File.ReadAllText("../../src/Exercise/Program.cs");
            int count = Regex.Matches(code, @"Dictionary").Count;

            Assert.True(count > 0/*, "Use a Dictionary in your code!"*/);
        }

        [Fact]
        public void TestForeachIsUsed()
        {
            string code = File.ReadAllText("../../src/Exercise/Program.cs");
            int count = Regex.Matches(code, @"foreach").Count;

            Assert.True(count > 0/*, "Use a foreach in your code!"*/);
        }

        [Fact]
        public void TestExercise138()
        {
            using (StringWriter sw = new StringWriter())
            {
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);

                // Call student's code
                Program.Main(null);

                // Restore the original standard output.
                Console.SetOut(stdout);

                // Assert
                Assert.Equal("matthew's nickname is matt\nmichael's nickname is mix\narthur's nickname is artie\n", 
                            sw.ToString().Replace("\r\n", "\n")/*, "Check your code!\nYou should print out exactly as the example says!"*/);
            }
        }
    }
}