# Salary Calculator TDD

In this project I followed the red-green-refactor (Test Driven Design) model. I started with the requirements to build two methods that can figure out hourly wage based on salary, and yearly salary based on hourly wage. I first created the test project and wrote my failing tests following the "arrange > act > assert" pattern. I then wrote the method to fulfill the first requirement until it passed my test. Finally, I went back and refactored my code and ran the test one more time to make sure it still passed.
  
I followed the same pattern for the next method: writing the failing unit test, writing the method until there is enough code to compile (<span style="color:red">failing</span>), writing the method until it passes (<span style="color:green">passing</span>), then refactoring the code (if needed) and making sure both tests still passed (<span style="color:green">passing</span>.)

    [TestMethod]
    public void AnnualSalaryTest()
    {
        // Arrange
        SalaryCalculator sc = new SalaryCalculator();
        // Act
        decimal annualSalary = sc.GetAnnualSalary(50);
        // Assert
        Assert.AreEqual(104000, annualSalary);
    }

    [TestMethod]
    public void HourlyWageTest()
    {
        // Arrange
        SalaryCalculator sc = new SalaryCalculator();
        // Act
        decimal hourlyWage = sc.GetHourlyWage(52000);
        // Assert
        Assert.AreEqual(25, hourlyWage);
    }
