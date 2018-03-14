using Microsoft.VisualStudio.TestTools.UnitTesting;
using palindrome;


namespace palindrome.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsPalindromeEmptyStringTest()
        {
            // Arrange
            string myString = "";
            PalindromeChecker p = new PalindromeChecker();

            // Act
            bool a = p.IsPalindrome(myString);

            // Assert
            Assert.AreEqual(true, a);          
        }

        [TestMethod]
        public void IsPalindromeOneCharacterTest()
        {
            // Arrange
            string myString = "a";
            PalindromeChecker p = new PalindromeChecker();

            // Act
            bool a = p.IsPalindrome(myString);

            // Assert
            Assert.AreEqual(true, a);
        }

        [TestMethod]
        public void IsPalindromeTwoCharacterTest()
        {
            // Arrange
            string myString = "ab";
            PalindromeChecker p = new PalindromeChecker();

            // Act
            bool a = p.IsPalindrome(myString);

            // Assert
            Assert.AreEqual(false, a);
        }

        [TestMethod]
        public void IsPalindromeFourCharacterTest()
        {
            // Arrange
            string myString = "abba";
            PalindromeChecker p = new PalindromeChecker();

            // Act
            bool a = p.IsPalindrome(myString);

            // Assert
            Assert.AreEqual(true, a);
        }

        [TestMethod]
        public void IsPalindromeMultiCharacterTest()
        {
            // Arrange
            string myString = "tattarrattat";
            PalindromeChecker p = new PalindromeChecker();

            // Act
            bool a = p.IsPalindrome(myString);

            // Assert
            Assert.AreEqual(true, a);
        }

        [TestMethod]
        public void IsPalindromeNullTest()
        {
            // Arrange
            string myString = null;
            PalindromeChecker p = new PalindromeChecker();

            // Act
            bool a = p.IsPalindrome(myString);

            // Assert
            Assert.AreEqual(false, a);
        }

    }
}
