# Battle Count Iterator
This was the first challenge I completed where I found two distinct ways to solve the problem. At first I created two variables and used the .Min and .Max functions on the arrays to determine the largest and smallest values. Then I searched through the arrays using a for loop and two if statements to find out which index had these values so we could match it to the value with the same index in the name array. Finally I added formatted strings to the result variable in each if statement once the name was found.
  
This solution worked with our static dataset, but closer looking at the data I realized it would show up in the other order if the lower value came before the larger value (resulting in very messy formatting.) To resolve this I had to go back to the drawing board, setting storage variables for the index and using my for loop to just search for the minimum and maximum index. I then moved my formatted strings outside of the for loop so I could control what order they appeared and used the indexes found in the loop to populate the data. This produced a much cleaner result that would work on different datasets. 
  
### Code Snipit:
'''
//variables to save indexes
int maximum = 0;
int minimum = 0;

//for loop to move through arrays and locate indexes
for (int i = 0; i < numbers.Length; i++)
{
    //this if statement continues to change the index stored in maximum
    //until it points to the highest value in the array
    if (numbers[i] > numbers[maximum])
    {
        maximum = i;
    }

    //this if statement continues to change the index stored in minimum
    //until it points to the lowest value in the array
    if (numbers[i] < numbers[minimum])
    {
        minimum = i;
    }
}

result = String.Format("Most battles belong to: {0} (Value: {1})"
    + "<br />Least battles belong to: {2} (Value: {3})", names[maximum], 
    numbers[maximum], names[minimum], numbers[minimum]);

resultLabel.Text = result;
'''