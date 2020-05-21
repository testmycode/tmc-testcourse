using System;
using System.IO;
using Xunit;
using Exercise;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseTest
{
    public class Tests
    {
        private Type ProgramType = typeof(Program);
        private MethodInfo MainMethod;
        private MethodBody MainMethodBody;

        public Tests()
        {
            this.MainMethod = this.ProgramType.GetMethod("Main", new[] { typeof(string[]) });
            this.MainMethodBody = this.MainMethod.GetMethodBody();
        }

        [Fact]
        public void TestMainExists()
        {
            Assert.NotNull(this.MainMethodBody/*, "Do not destroy the Main class from Program.cs!"*/);
        }

        [Fact]
        public void TestDictionaryIsUsed()
        {
            IList<LocalVariableInfo> locals = this.MainMethodBody.LocalVariables;

            //This could be made more strict by requiring specific key and value types
            Assert.True(locals.Any(local =>
                local.LocalType.IsGenericType &&
                local.LocalType.GetGenericTypeDefinition() == typeof(Dictionary<,>)), "Use a Dictionary in your code!");
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