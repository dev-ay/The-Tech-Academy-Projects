using System;
using Xunit;
using Polymorphism.Core;


namespace Polymorphism.Test
{
    public class UnitTest1
    {
        [Fact]
        public void CalculateWeeklySalaryForEmployeeTest_70wage55hoursReturns28000Dollars()
        {
            // Arrange
            int weeklyHours = 55;
            int wage = 70;
            int salary = 40 * wage;
            Employee e = new Employee();

            string expectedResponse = String.Format("This ANGRY EMPLOYEE worked {0} hrs. " +
                              "Paid for 40 hrs at $ {1}" +
                              "/hr = ${2}", weeklyHours, wage, salary);
            // Act
            string response = e.CalculateWeeklySalary(weeklyHours, wage);
            // Assert
            Assert.Equal(response, expectedResponse);
        }

        [Fact]
        public void CalculateWeeklySalaryForContractorTest_70wage55hoursReturns3850Dollars()
        {
            // Arrange
            int weeklyHours = 55;
            int wage = 70;
            int salary = weeklyHours * wage;
            Contractor e = new Contractor();

            string expectedResponse = String.Format("This HAPPY CONTRACTOR worked {0} hrs. " +
                              "Paid for {0} hrs at $ {1}" +
                              "/hr = ${2}", weeklyHours, wage, salary);
            // Act
            string response = e.CalculateWeeklySalary(weeklyHours, wage);
            // Assert
            Assert.Equal(response, expectedResponse);
        }

        [Fact]
        public void CalculateWeeklySalaryForEmployeeTest_70wage55hoursDoesNotReturnCorrectString()
        {
            // Arrange
            int weeklyHours = 55;
            int wage = 70;
            int salary = 40 * wage;
            Employee e = new Employee();

            string expectedResponse = String.Format("Problem 1 - This ANGRY EMPLOYEE worked {0} hrs. " +
                              "Paid for 40 hrs at $ {1}" +
                              "/hr = ${2}", weeklyHours, wage, salary);
            // Act
            string response = e.CalculateWeeklySalary(weeklyHours, wage);
            // Assert
            Assert.NotEqual(response, expectedResponse);
        }

        [Fact]
        public void CalculateWeeklySalaryForContractorTest_70wage55hoursDoesNotReturnCorrectString()
        {
            // Arrange
            int weeklyHours = 55;
            int wage = 70;
            int salary = weeklyHours * wage;
            Contractor e = new Contractor();

            string expectedResponse = String.Format("Problem 2 - This HAPPY CONTRACTOR worked {0} hrs. " +
                              "Paid for {0} hrs at $ {1}" +
                              "/hr = ${2}", weeklyHours, wage, salary);
            // Act
            string response = e.CalculateWeeklySalary(weeklyHours, wage);
            // Assert
            Assert.NotEqual(response, expectedResponse);
        }
    }
}
