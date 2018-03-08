# Unit Testing in C#

This is a quick unit test I wrote for a C# class library. I am reading The Art of Unit Testing and wanted to practice using some of Visual Studio's built-in testing functionality by creating a test project.

### Code Snippet:

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