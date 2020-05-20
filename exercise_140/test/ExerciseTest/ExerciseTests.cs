using System;
using System.IO;
using Xunit;
using Exercise;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ExerciseTest
{
    public class Tests : IDisposable
    {
        string target = "../../../";
        string current = Directory.GetCurrentDirectory();

        public Tests() {
            Directory.SetCurrentDirectory(target);
        }

        public void Dispose()
        {
            Directory.SetCurrentDirectory(current);
        }

        [Fact]
        public void TestMainExists()
        {
            string code = File.ReadAllText("../../src/Exercise/Program.cs");
            int count = Regex.Matches(code, @"public static void Main\(string\[\] args\)").Count;

            Assert.Equal(1, count/*, "Do not destroy the Main class from Program.cs!"*/);
        }

        [Fact]
        public void TestDictionaryIsUsedInClass()
        {
            string code = File.ReadAllText("../../src/Exercise/Program.cs");
            int count = Regex.Matches(code, @"Dictionary").Count;

            Assert.True(count > 0/*, "Use Dictionary in your Program!"*/);
        }

        [Fact]
        public void TestPrintKeys()
        {
            using (StringWriter sw = new StringWriter())
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintKeys(dict);
                Console.SetOut(stdout);

                // Assert
                Assert.Contains("f.e", sw.ToString().Replace("\r\n", "\n")/*, "You should print the keys with PrintKeys!"*/);
                Assert.Contains("etc", sw.ToString().Replace("\r\n", "\n")/*, "You should print the keys with PrintKeys!"*/);
                Assert.Contains("i.e", sw.ToString().Replace("\r\n", "\n")/*, "You should print the keys with PrintKeys!"*/);
                Assert.Contains("jne", sw.ToString().Replace("\r\n", "\n")/*, "You should print the keys with PrintKeys!"*/);
            }
        }

        [Fact]
        public void TestPrintKeysWhereI()
        {
            using (StringWriter sw = new StringWriter())
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintKeysWhere(dict, "i");
                Console.SetOut(stdout);

                // Assert
                Assert.Equal("i.e\n", sw.ToString().Replace("\r\n", "\n")/*, "You should only print the keys with given letter\nWith PrintKeysWhere!"*/);
            }
        }


        [Fact]
        public void TestPrintKeysWhereJ()
        {
            using (StringWriter sw = new StringWriter())
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintKeysWhere(dict, "j");
                Console.SetOut(stdout);

                // Assert
                Assert.Equal("jne\n", sw.ToString().Replace("\r\n", "\n")/*, "You should only print the keys with given letter\nWith PrintKeysWhere!"*/);
            }
        }

        [Fact]
        public void TestPrintKeysWhereDotE()
        {
            using (StringWriter sw = new StringWriter())
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintKeysWhere(dict, ".e");
                Console.SetOut(stdout);

                // Assert
                Assert.Contains("f.e", sw.ToString().Replace("\r\n", "\n")/*, "You should only print the keys with given letter\nWith PrintKeysWhere!"*/);
                Assert.Contains("i.e", sw.ToString().Replace("\r\n", "\n")/*, "You should only print the keys with given letter\nWith PrintKeysWhere!"*/);
            }
        }

        [Fact]
        public void TestPrintValuesWhereDotE()
        {
            using (StringWriter sw = new StringWriter())
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintValuesOfKeysWhere(dict, ".e");
                Console.SetOut(stdout);

                // Assert
                Assert.Contains("for example", sw.ToString().Replace("\r\n", "\n")/*, "You should print the values!"*/);
                Assert.Contains("more precisely", sw.ToString().Replace("\r\n", "\n")/*, "You should print the values!"*/);
                Assert.DoesNotContain("ja niin edelleen", sw.ToString().Replace("\r\n", "\n")/*, "You should print the values!"*/);
            }
        }
    }
}