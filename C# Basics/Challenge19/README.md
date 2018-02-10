# Spy Assignment Form

This was a fun challenge! We were given “business rules” to create an application that allows the user to create a “spy mission” and review the cost while enforcing certain constraints on mission frequency. To complete the challenge I had to put some code in the load section of the page that only ran the first time the page was created so that there would be default values displayed. After that I wrote the logic to generate the cost, finding the timespan between two dates, taking the absolute value and multiplying it by the cost per day. I added an if branch that would add the additional > 21 days fee, then a second set of branching statements to enforce the mission frequency requirements.
  
This was the first time I used breakpoints in Visual Studio to troubleshoot code and it was very helpful to be able to step through and see the values being given to my variables. I was able to use this to find where things weren’t working and make adjustments much faster.
  
*Click [here](https://gist.github.com/jhunschejones/c744d49358dce1e5bd7829f03302c1ca) to see a snippit of the code I wrote to complete this challenge.*

## Here are the rules assigned in the challenge:
  
Business Rule 1: Initialize the calendar controls. Make sure the end of the previous assignment date is set to today.  Make sure the start date of the new assignment is set for an additional 14 days from today.  Make sure the end date of the new assignment is set for an additional 21 days from today.
  
Business Rule 2: The United Spy Workers Union dictates there must be at least two weeks of paid time between assignments.  If at least two weeks are not selected between the previous assignment and the new assignment display an error message.  (See mockup #3.)  Also, show the manager the earliest available date on the calendar by selecting and showing that date in the "Start of New Date" Calendar.
  
Business Rule 3: Spies cost $500 per day against your Assignment's budget.  Display the budget to the manager in text at the bottom of the web page.  (See mock-up #2.)
  
Business Rule 4: If the assignment is greater than three weeks, an additional $1,000 budget fee will be assessed.
