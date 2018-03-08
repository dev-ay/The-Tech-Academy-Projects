using System;
using Xunit;
using FirstUnitTest;

namespace FirstUnitTest.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var testInstance = new Class1();
            var testResult = testInstance.AddTwoNumbers(4, 5);
            Assert.Equal(9, testResult);
        }
    }
}
