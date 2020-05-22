using System;
using System.IO;
using Xunit;
using Exercise;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseTest
{
    public class Tests
    {
        private Type ProgramType = typeof(Program);
        private Type AbbreviationsType = typeof(Abbreviations);
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
        public void TestAbbreviationsIsCreated()
        {   
            Assert.NotNull(AbbreviationsType/*, "Create the Abbreviations class!"*/);
        }

        [Fact]
        public void TestDictionaryIsUsed()
        {
            /*
            IList<LocalVariableInfo> locals = this.MainMethodBody.LocalVariables;

            //This could be made more strict by requiring specific key and value types
            Assert.True(locals.Any(local =>
                local.LocalType.IsGenericType &&
                local.LocalType.GetGenericTypeDefinition() == typeof(Dictionary<,>)), "Use a Dictionary in your abbreviations class!");
            */

            Type AbbreviationsType = typeof(Abbreviations);
            FieldInfo[] fields = AbbreviationsType != null ? AbbreviationsType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance) : new FieldInfo[0];
            bool hasDict = fields.Any(field => field.FieldType == typeof(Dictionary<string, string>));
            Assert.True(hasDict, "Use a Dictionary<string, string> in your abbreviations class!");
        }

        [Fact]
        public void TestAbbreviationsClassHasAbbs()
        {
            Abbreviations abbs = new Abbreviations();
            abbs.AddAbbreviation("np", "no problem");
            // Assert
            Assert.True(abbs.HasAbbreviation("np")/*, "HasAbbreviation should find the added abbreviation!"*/);
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