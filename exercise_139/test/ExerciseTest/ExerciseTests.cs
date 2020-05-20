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
        public void TestAbbreviationsIsCreated()
        {
            string code = File.ReadAllText("../../src/Exercise/Abbreviations.cs");
            int count = Regex.Matches(code, @"public class Abbreviations").Count;

            Assert.True(count > 0/*, "Create the Abbreviations.cs file!"*/);
        }

        [Fact]
        public void TestDictionaryIsUsedInClass()
        {
            string code = File.ReadAllText("../../src/Exercise/Abbreviations.cs");
            int count = Regex.Matches(code, @"Dictionary").Count;

            Assert.True(count > 0/*, "Use Dictionary in your Class!"*/);
        }

        [Fact]
        public void TestAbbreviationsClassHasAbbs()
        {
            Abbreviations abbs = new Abbreviations();
            abbs.AddAbbreviation("np", "no problem");
            // Assert
            Assert.True(abbs.HasAbbreviation("np")/*, "HasAbbrebiation should find the added abbreviation!"*/);
        }

        [Fact]
        public void TestAbbreviationsClassFindExpNP()
        {
            Abbreviations abbs = new Abbreviations();
            abbs.AddAbbreviation("np", "no problem");
            // Assert
            Assert.Equal("no problem", abbs.FindExplanationFor("np")/*, "FindExplanation should find the explanation!"*/);
        }

        [Fact]
        public void TestAbbreviationsClassFindExpETC()
        {
            Abbreviations abbs = new Abbreviations();
            abbs.AddAbbreviation("etc", "et cetera");
            // Assert
            Assert.Equal("et cetera", abbs.FindExplanationFor("etc")/*, "FindExplanation should find the explanation!"*/);
        }

        [Fact]
        public void TestAbbreviationsClassFindExpJNE()
        {
            Abbreviations abbs = new Abbreviations();
            abbs.AddAbbreviation("jne", "ja niin edelleen");
            // Assert
            Assert.Equal("ja niin edelleen", abbs.FindExplanationFor("jne")/*, "FindExplanation should find the explanation!"*/);
        }

        [Fact]
        public void TestAbbreviationsClassDoNotFindUnexisting()
        {
            Abbreviations abbs = new Abbreviations();
            // Assert
            Assert.Equal("not found", abbs.FindExplanationFor("jne")/*, "FindExplanation should return 'not found' if the abbreviation does not exist!"*/);
        }
    }
}