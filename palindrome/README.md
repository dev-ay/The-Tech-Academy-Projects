# Palindrome Challenge

## Objective
* Create a method that can check if a string is a palindrome or not, assuming input can only be a string or null. 
* Optimize for short or empty strings.
* Create unit tests for method

## Steps taken 
Though a major portion of this challenge was focused on creating the unit tests, my biggest struggle was properly handling null values in my actual method before I could test it! Out of habit I had set my variables at the top of my method but after running into null errors, I realized I needed to check for null first before going to set my variables. From there I could kill two birds with one stone optimizing for null input and strings that were empty or contained 1 character. After that, I set my variables to chop my string up and reverse it, then check longer strings against their reverse to see if they are equal.
  
## Outcome
I wrote unit tests for 100% of the test cases mentioned in the assignment and even though I was writing the tests after writing the function (not test-driven-design), they still helped me refactor my function to correct the problem I was having accepting null values. Unit tests have done it again!

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
