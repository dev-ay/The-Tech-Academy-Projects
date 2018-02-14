# Slot Machine

## Overview/Requirements:
The user should be able to enter a value in a text box and click a "pull" button producing several results. Three pictures will be selected at random and depending on those pictures and the amount of money the user "bet" a message will be returned saying the user won or lost. In addition, there is a user "bank" of money that goes up or down by set amounts based on how much the user wins or loses. 

## Steps Taken:
I created several helper methods to break this problem down into manageable parts. First, I built a code block to run on page load to display three random images. This is done by naming the images with a number and generating a random number between 1-12. The number is then appended to the image name and displayed. Based on the value/name of the image selected, the values are passed along to one of three methods to calculate the amount of money the user "wins." Finally there is a method to print out a message to the user telling them if they won or lost (and how much).
  
I stored the user's amount of money in the view state so that it could be retrieved, modified and re-saved between user clicks of the button.

## Results:
The final program works as required, allowing the user to win or lose based on the picture that comes up through the random generator. The money/bank value is collected and modified throughout the gameplay, showing the player if they are making or losing money over time.
  
I am most proud of how seamlessly the variable values are passed from one helper method to another, and how cleanly the process of storing and retrieving a value in the viewstate works. It was quite a challenge to divide the requirements into manageable parts, but it really pushed me to research and learn more about the tools I used. I am definitely leaving this challenge more confident that I can solve even bigger challenges moving forward. 
