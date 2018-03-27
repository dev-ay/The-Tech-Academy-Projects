# C# Testing 3

In this project I was given a completed solution with the assignment of writing unit tests to provide 100% coverage. This is obviously not ideal test-driven design, but it is realistic practice for a scenario where I might inherit a code base and need to bolster the testing coverage.
  
First I broke down the initial project to determine what each method was attempting to do. I then wrote four failing tests to test problems with the output as well as the expected output. The reason to write your tests failing first is so you can confirm that they work as intended. This is not as foolproof as writing the tests before the code, but it adds one layer of verification that the tests are testing what I think they are.
  
Finally I corrected the tests to pass. The four tests check that the expected output is returned and that a problem in the result string should give me a different final output. It is possible to more tests might be needed depending on the use of the program, but if the program just preforms this one hard-coded calculation, this does represent good unit test coverage.