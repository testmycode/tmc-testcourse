using System;
using Xunit;
using TestProject;

namespace TestProjectTests
{
    public class ProgramTest
    {
        [Fact]
        public void TestReturnsTrue()
        {
            Assert.True(Program.ReturnTrue);
        }

        [Fact]
        public void ReturnsNotInput()
        {
            Assert.True(Program.ReturnNotInput(false));
            Assert.False(Program.ReturnNotInput(true));
        }

        [Fact]
        public void ReturnsString()
        {
            string s = "asd";
            Assert.Equal(s, Program.ReturnInputString(s));
        }
    }
}
