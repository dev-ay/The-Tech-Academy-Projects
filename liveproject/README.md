# Live Project

## Introduction
For my final project at The Tech Academy, I worked with a development team of my peers on a full-scale social media/traveling app in C#. It was a great opportunity to take on a legacy code base, see how the code was laid out, fix bugs, and add requested features. I saw first-hand how an app can evolve over time and outgrow some of the early choices the original developers made while building it. When changing direction on big decisions would require a larger rewrite that the client does not have time for, I saw how good developers can pick up what was there and make the best of the situation to deliver a quality product. We worked together as a team to learn the quirks of how the application was first written and how we could work within those constraints to still deliver the desired what was asked of us.

## Stories I Worked On

### Change Button Font Color
When it comes to picking up large code bases, I like starting with specific tasks in the actual code like tracing a specific functionality I know I will be working with, or finding where a bug is occuring. I find this helps me understand how the original developers built out the app and where to look for different things in the project structure. With this in mind, the first story I took was to update the font color of the button users click to submit reviews for a location they've traveled to. Though this sounds simple, I actually ran into a problem off the bat--the project had some style written in SASS and some in CSS, and there were often several overlapping targets for the same element. This meant the first place I thought to look for the change wasn't right and I had to keep tracing the places where previous developers had targeted the same ID to find what was taking precedence and make my change there. It was actually in the 5th place I looked that I found where the CSS was setting the font color and when I changed it there it finally worked on the page as the story had requested.

### Change Header Tags
After completing that more straight-forward front-end story, I started work on a more challenging back end story to push myself. I ran into some blockers with updating the ViewModel, so while I was working with a senior developer to troubleshoot, I completed another front end story. This story required a change to a view partial so that the h3 and h1 tags could be attached to the correct elements for the look the client desired. The challenge with this story was that the change needed to occur on a page where the database in development did not have access to the images the ViewModel was asking for (to pass to the View.) This caused the app to error out when a user navigated to the page to see the updated html. Because the ViewModel C# code works in production, I went around this by passing in an empty string for the image path so that the page could load without images and display my html changes and confirm I had completed the changes the story requested.

### Change Posted on Date
This story requested that I remove a date that was shown at the bottom of a posted review and place it under the user's picture and link. It also asked that the format be changed from "{day of week} {month} {day}, {year}" to "Posted on {month} {day}, {year}". Moving html that displayed the date to the new location was no problem, then I had to use some string manipulation to get the new display format being asked for. This is the code I used:
    <h5>Posted on @Html.DisplayFor(modelItem => item.DatePosted.Split(',')[1]), @Html.DisplayFor(modelItem => item.DatePosted.Split(',')[2])</h5>
This takes the date, which is stored in the database with the old format, and splits it up into an array, displaying the new pieces that we actually want in the format that was requested. 

### Fixing Assignment Bug
When working on a portion of the reviews page, I ran into a bug that another developer had worked on earlier. Because our development database's do not have links to the review pictures, reviewPicture was coming in as null when trying to load the page and causing the page to break. I had worked around this to complete one of the other stories I described above, but it was apparent that it would need to be actually solved if we were going to do a lot of work on the review page. The fix in place was an if-else statement but I found the page was still breaking because it was not allowing us to call ".Path" on a null value. I changed the if-else statement to a ternary statement with a clarified null check and the page was able to load.
    // Before
    if (reviewPicture.Path == null) {
        ReviewPicture = null
    } else {
        ReviewPicture = reviewPicture.Path
    }

    // After
    ReviewPicture = (reviewPicture == null) ? ReviewPicture = null : ReviewPicture = reviewPicture.Path;

### Add Flag Bug
There is a button on the reviews page to add a flag to a review when a user feels it has inappropriate or inaccurate content. With all the conflicting stylesheets in this project, the test was displayed to one side of the button creating a sloppy feel to the "add flag" modal. I found the button element and added an ID, then found the CSS file that had other flag-related styling and adjusted the padding so the text looks nice and centered.
   #add-flag-btn {
   padding: 5px 10px 5px 10px;
   }

### Photo Likes
On the travel photos page of the app, there was a thumbs up button that allows a user to like a photo. Displayed over the button was a small badge that showed the total number of likes. This story was asking that the likes be incremented and decremented if the user clicked on the badge or the icon. The icon already functioned the way it was intended, so it was a matter of also applying this functionality to the badge as well.
 The first hurdle was starting to feel familiar: there were no photos on the travel photos page for me to test the functionality. Additionally, attempting to add a review with a photo broke the app so there was work to do even before I could start working on the functionality of the likes badge.

#### Note:
* The code to change is in Views > Posts > PublicImages.cshtml, just need to add link to like count span
* First we need to get an image in here!

