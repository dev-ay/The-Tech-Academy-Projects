# Shipping Calculator

## Overview
In this challenge, I had to create a shipping calculator that would return shipping rates based on a set of business requirements.
  
Business Rule 1: Accept width, height and optionally the length of a parcel. Accept the shipping method - Ground, Air, Next Day.
  
Business Rule 2: Once you have the minimum amount of information you need, produce a result on screen. The result will be the volume of the package (width * height and optionally * length) multiplied by the "multiplier" for each shipping method.
  
Ground: .15 multiplier
Air: .25 multiplier
Next Day: .45
  
## Steps Taken
I first created the helper methods to perform the different tasks I would need: check the values, calculate volume, calculate shipping, and output shipping cost with the required text string. Everything in these methods worked except my first method that was supposed to assure at least the height and width were entered. In order to trace the problem all the way back to the start, I put in print instructions at different points in the application and slowly built up the structure of my first helper method. I discovered what I needed to do was create nested if-statements that would try to parse the values being entered by the user. These essentially function like gatekeepers and pass along the values to my other helper methods. Once the variables were passed along to the volume method there is a final helpful error message that can be displayed if I need the user to input a non-zero value.

## Results
The final application will calculate shipping rates based on the business requirements once at least the width and height are entered and one radio button is checked. It will not output rates if not enough information is entered, or if the values entered are not valid.

### Code Snippet: 
    // set variables
    double volume = 0;
    double shipping = 0;
    double width = 0;
    double height = 0;
    double length = 0;

    private void checkValues()
    {
        if (Double.TryParse(widthTextBox.Text, out width)) {
            if (Double.TryParse(heightTextBox.Text, out height))
            {
                Double.TryParse(lengthTextBox.Text, out length);
                calculateVolume(width, height, length);
            }
        }
    }

    private void calculateVolume(double width = 0, double height = 0, double length = 0)
    {      
        if (width == 0 || height == 0)
        {
            resultLabel.Text = "You must enter a width and height to calculate.";
        } 
        else {
            if (length == 0)
            {
                volume = width * height;
                calculateShipping(volume);
            }
            else
            {
                volume = length * width * height;
                calculateShipping(volume);
            }
        }
    }

    private void calculateShipping(double volume)
    {
        //takes in volume and calulates shipping
        if (groundButton.Checked)
        {
            shipping = volume * 0.15;
            printResults(shipping);
        }
        else if (airButton.Checked)
        {
            shipping = volume * 0.25;
            printResults(shipping);
        }
        else if (nextDayButton.Checked)
        {
            shipping = volume * 0.45;
            printResults(shipping);
        }
        else return; 
    }

    private void printResults(double shipping)
    {
        resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship.", shipping);
    }
