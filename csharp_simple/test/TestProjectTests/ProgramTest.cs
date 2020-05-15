using System;
using Xunit;
using TestProject;
using TestMyCode.Csharp.API.Attributes;

namespace TestProjectTests
{
    public class ProgramTest
    {
        [Fact]
        [Points("1.3")]
        public void TestReturnsTrue()
        {
            Assert.True(Program.ReturnTrue);
        }

        [Fact]
        [Points("0.5")]
        public void ReturnsNotInput()
        {
            Assert.True(Program.ReturnNotInput(false));
            Assert.False(Program.ReturnNotInput(true));
        }

        [Fact]
        [Points("2.1")]
        public void ReturnsString()
        {
            string s = "asd";
            Assert.Equal(s, Program.ReturnInputString(s));
        }
    }
}
