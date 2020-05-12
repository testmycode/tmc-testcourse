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
    }
}
