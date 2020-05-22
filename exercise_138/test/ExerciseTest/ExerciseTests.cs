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
        public void TestForeachIsUsed()
        {
            IList<ExceptionHandlingClause> exceptionHandlers = this.MainMethodBody.ExceptionHandlingClauses;

            //Foreach generates hidden finally block
            bool hasFinally = exceptionHandlers.Any(handler =>
                handler.Flags == ExceptionHandlingClauseOptions.Finally);

            IList<LocalVariableInfo> locals = this.MainMethodBody.LocalVariables;

            //Foreach uses GetEnumerator() internally
            bool hasEnumerator = locals.Any(local => 
                local.LocalType.IsGenericType &&
                local.LocalType.GetGenericTypeDefinition() == typeof(Dictionary<,>.Enumerator));

            bool hasKeyValuePair = locals.Any(local => 
                local.LocalType.IsGenericType &&
                local.LocalType.GetGenericTypeDefinition() == typeof(KeyValuePair<,>));

            Assert.True(hasFinally && hasEnumerator && hasKeyValuePair, "Use a foreach in your code!");
        }

        [Fact]
        public void TestExercise138()
        {
            using (StringWriter sw = new StringWriter())
            {
                //sw.NewLine = "\r\n";
                sw.NewLine = "\n";

                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);

                // Call student's code
                Program.Main(null);

                // Restore the original standard output.
                Console.SetOut(stdout);

                // Assert
                Assert.StartsWith("matthew's nickname is matt\nmichael's nickname is mix\narthur's nickname is artie", sw.ToString());
            }
        }
    }
}