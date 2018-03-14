using System;

namespace palindrome
{
    public class PalindromeChecker
    {
        public bool IsPalindrome(string myString) {

            // check for null first
            if (string.IsNullOrEmpty(myString) && myString != "")
            {
                return false;
            }
            // catch empty string and strings of 0 or 1 characters
            else if (myString.Length < 2)
            {
                return true;
            }

            // convert string to array, reverse, convert back to string
            char[] myArray = myString.ToCharArray();
            Array.Reverse(myArray);
            string myStringReverse = new string(myArray);

            // catch longer strings
            if (myString == myStringReverse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
