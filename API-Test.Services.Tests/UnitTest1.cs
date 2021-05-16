using System;
using Xunit;

namespace API_Test.Services.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int expectResult = 10;

            int a = 5;
            int b = 2;

            int actual = a * b;

            Assert.Equal(expectResult, actual);
        }
    }
}
