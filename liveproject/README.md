# Live Project

## Introduction
For my final project at The Tech Academy, I worked with a development team of my peers on a full-scale MVC/MVVM social media/traveling app in C#. It was a great opportunity to take on a legacy code base, see how the code was laid out, fix bugs, and add requested features. I saw first-hand how an app can evolve over time and outgrow some of the early choices the original developers made while building it. When changing direction on big decisions would require a larger rewrite that the client does not have time for, I saw how good developers can pick up what was there and make the best of the situation to deliver a quality product. We worked together as a team to learn the quirks of how the application was first written and how we could work within those constraints to still deliver the desired what was asked of us. During the two-week project I worked on a few [back end stories](#back-end-stories) that I am very proud of. Because much of the site had already been built, there was also a good deal of [front end stories](#front-end-stories) that needed to be completed, all of varying degrees of difficulties. We shared the stories available so that everyone on the team would have a chance to work on some front end and some back end content.

## Back End Stories
* [Fixing Assignment Bug](#fixing-assignment-bug)
* [Photo Likes](#photo-likes)
* [Create AdminFlagViewModel](#create-adminflagviewmodel)

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

*To: [Front End Stories](#front-end-stories), [Back End Stories](#back-end-stories)*

### Photo Likes
On the travel photos page of the app, there was a thumbs up button that allows a user to like a photo. Displayed over the button was a small badge that showed the total number of likes. This story asked that the likes be incremented and decremented if the user clicked on the badge *or* the icon. The icon already functioned the way it was intended, so it was a matter of also applying this functionality to the badge as well.
  
The first hurdle was starting to feel familiar: there were no photos on the travel photos page for me to test the functionality. Additionally, attempting to add a review with a photo broke the app so there was work to do even before I could start working on the functionality of the likes badge.

A senior developer was able to debug a recent push a developer from a previous team had done that was causing the error. This allowed the travel photos page to display the images I needed so I could get to work. Here's the code I started with: 

    // before
    if (item.ImageLiked == false)
    {
        <i class="like-post fa-stack fa fa-thumbs-o-up fa-stack-2x" id="@item.ImageID" onclick="LikeImage(@item.ImageID, this)"></i>
    }
    else
    {
        <i class="unlike-post fa-stack fa fa-thumbs-o-up fa-stack-2x" id="@item.ImageID" onclick="UnlikeImage(@item.ImageID, this)"></i>
    }

    if (item.ImageLikeCount == 1)
    {
        <span class="fa-stack LikeCount" id="@item.ImageID-LikeCount">@item.ImageLikeCount</span>//<span id="@item.ImageID-LikePluralize"></span>
    }
    else
    {
        <span class="fa-stack LikeCount" id="@item.ImageID-LikeCount">@item.ImageLikeCount</span>//<span id="@item.ImageID-LikePluralize"></span> 
    }

The first set of if/else branching produced the like icon that incremented or decremented the likes. The second set of if/else branching looked like it was not doing anything and this turned out to be correct-- it was left over from a previous pluralize function that was no longer being used. (I spoke with the senior developer who was more familiar with this project to confirm that it was okay to remove this extra code.)
  
With this clarified, I cleaned up the code and included both elements with increment and decrement onclick functions in the same place so it would be easier to read and understand for the next developer.

    // after
    if (item.ImageLiked == false)
    {
        // thumb icon, unliked
        <i class="like-post fa-stack fa fa-thumbs-o-up fa-stack-2x" id="@item.ImageID" onclick="LikeImage(@item.ImageID, this)"></i>
        // like-count badge, unliked
        <span class="fa-stack LikeCount" id="@item.ImageID-LikeCount" onclick="LikeImage(@item.ImageID, this)">@item.ImageLikeCount</span>
    }
    else
    {
        // thumb icon, liked
        <i class="unlike-post fa-stack fa fa-thumbs-o-up fa-stack-2x" id="@item.ImageID" onclick="UnlikeImage(@item.ImageID, this)"></i>
        // like-count badge, liked
        <span class="fa-stack LikeCount" id="@item.ImageID-LikeCount" onclick="UnlikeImage(@item.ImageID, this)">@item.ImageLikeCount</span>
    }

With that change the page was working so that if the user clicked the badge or the icon it would like or unlike the picture the same way. I'm sure users won't think of the layout this way, as two seperate elements on top of eachother, but I imagine this change will avoid some potential confusion about why some clicks work and others don't. To help further smooth out the experience, I also added a couple lines of CSS so that when the mouse hovers over the like-count badge or the icon, it will have the same pointer cursor (previously it was the default cursor on the icon and the text cursor on the badge, neither of which suggests to the user that it's a place to click.)

    .like-post :hover {
    color: #62B18B;
    cursor: pointer;
    }

    .unlike-post :hover {
    color: grey;
    cursor: pointer;
    }

    .LikeCount :hover {
        /* ... */
        cursor: pointer;
    }

*To: [Front End Stories](#front-end-stories), [Back End Stories](#back-end-stories)*

### Create AdminFlagViewModel
The site has some flagging functionality that allows users to flag images they believe are inappropriate, inaccurate, or someone else's property. Currently there is not an easy way for administrators to view the list of flagged images to decide what to do with them. As a team, we are starting to put together this functionality and the first step was to create our ViewModel and add the logic into the controller to pass a list of these objects to our view.

    // AdminFlagViewModel
    public class AdminFlagViewModel
    {
        // properties
        public int FlagID { get; set; }
        //What kind of Flag is it
        public FlagOption FlagStatus { get; set; }
        public int? Post_ID { get; set; }
        public string User_ID { get; set; }
        public int? Review_ID { get; set; }
        // Review or Post selected based on the FlagTarget
        public virtual Review Review { get; set; }
        public virtual Post Post { get; set; }
        // who flagged it
        public virtual User UserFlagging { get; set; }
        public DateTime DateFlagged { get; set; }

        // constructors
        public AdminFlagViewModel() { }
    }

    // for AdminController
    public ActionResult FlaggedContent ()
    {
        List<AdminFlagViewModel> flagged = new List<AdminFlagViewModel>();

        return View(flagged);
    }

*To: [Front End Stories](#front-end-stories), [Back End Stories](#back-end-stories)*

## Front End Stories
* [Change Button Font Color](#change-button-font-color)
* [Change Header Tags](#change-header-tags)
* [Change Posted on Date](#change-posted-on-date)
* [Add Flag Layout Bug](#add-flag-layout-bug)
* [Fix Reviews Background Image](#fix-reviews-background-image)
* [Fix Home Page Button](#fix-home-page-button)
* [Fix Right Side Margins](#fix-right-side-margins)
* [Message Dropdown Cursors](#nessage-dropdown-cursors)

### Change Button Font Color
This story asked that I update the font color of the button users click to submit reviews for a location they've traveled to. Though this sounds simple, I actually ran into a problem off the bat--the project had some style written in SASS and some in CSS, and there were often several overlapping targets for the same element. This meant the first place I thought to look for the change wasn't right and I had to keep tracing the places where previous developers had targeted the same ID to find what was taking precedence and make my change there. It was actually in the 5th place I looked that I found where the CSS was setting the font color and when I changed it there it finally worked on the page as the story had requested.  
*To: [Front End Stories](#front-end-stories), [Back End Stories](#back-end-stories)*

### Change Header Tags
This story required a change to a view partial so that the h3 and h1 tags could be attached to the correct elements for the look the client desired. The challenge with this story was that the change needed to occur on a page where the database in development did not have access to the images the ViewModel was asking for (to pass to the View.) This caused the app to error out when a user navigated to the page to see the updated html. Because the ViewModel C# code works in production, I went around this by passing in an empty string for the image path so that the page could load without images and display my html changes and confirm I had completed the changes the story requested.  
*To: [Front End Stories](#front-end-stories), [Back End Stories](#back-end-stories)*

### Change Posted on Date
This story requested that I remove a date that was shown at the bottom of a posted review and place it under the user's picture and link. It also asked that the format be changed from "{day of week} {month} {day}, {year}" to "Posted on {month} {day}, {year}". Moving html that displayed the date to the new location was no problem, then I had to use some string manipulation to get the new display format being asked for. This is the code I used:

    <h5>Posted on @Html.DisplayFor(modelItem => item.DatePosted.Split(',')[1]), @Html.DisplayFor(modelItem => item.DatePosted.Split(',')[2])</h5>

This takes the date, which is stored in the database with the old format, and splits it up into an array, displaying the new pieces that we actually want in the format that was requested.  
*To: [Front End Stories](#front-end-stories), [Back End Stories](#back-end-stories)*

### Add Flag Layout Bug
There is a button on the reviews page to add a flag to a review when a user feels it has inappropriate or inaccurate content. With all the conflicting stylesheets in this project, the test was displayed to one side of the button creating a sloppy feel to the "add flag" modal. I found the button element and added an ID, then found the CSS file that had other flag-related styling and adjusted the padding so the text looks nice and centered.

   #add-flag-btn {
   padding: 5px 10px 5px 10px;
   }

*To: [Front End Stories](#front-end-stories), [Back End Stories](#back-end-stories)*

### Fix Reviews Background Image
For this story, I was focusing on the background image displayed on the create reviews page. It had been put in as an image tag but since it was loading inside a container element, the parent element's padding and margin properties were causing it to shift to one side. I looked through the other pages on the site that had nice backgrounds and it looked like in general, we were using CSS to put in background images. 

    <style>
        body {
            background-image: url("../Images/Home/menu-cafe.jpg");
            background-attachment: fixed;
        }
    </style>

*To: [Front End Stories](#front-end-stories), [Back End Stories](#back-end-stories)*

### Fix Home Page Button
On the home page there is a main action button that says "sign in" when a user is not signed in. When browsing the site looking for usability improvements, I noticed that once I was signed in it now said "sign up." The button functionality also now pointed to the "connect" page. I checked with the team and they did not believe this was a client request, so I adjusted the text to read "Connect" so that it more accurately described where it was pointing the user.

    if (!Request.IsAuthenticated)
    {
        <a href='@Url.Action("Login", "Account")' class="bttn btn-ghost hidden-xs-down">Sign In</a>
    }
    else
    {
        <a href='@Url.Action("Index", "Reviews", new { userID = User.Identity.GetUserId() }, null)' class="bttn btn-ghost hidden-xs-down">Connect</a>
    }

*To: [Front End Stories](#front-end-stories), [Back End Stories](#back-end-stories)*

### Fix Right Side Margins
After looking at the site for so long, I had gotten used to a weird right side margin that displayed on all the pages, then got worse on the home and login pages. It took a good deal of searching to find where this was occurring but I discovered the problem was that we may have too much formatting set in our layout partial that is pulled into every page on the site. Other pages addressed this by adding inline styles, so instead of affecting the template view for the whole site I was able to clean up the margin by first commenting out one margin that was set for the whole site in styles.css. Then I added a little workaround to reach back up and add style to the parent element coming in from the template layout once I was in the home page:

    <script>
        $("#content").css({ "top": "53px", "right": "-17px", "bottom": "43px" });
    </script>

I realize that in-line style and script is not the best approach to a situation like this for the long term, but completing a quick fix for the client without rewriting the template this seemed like a workable option. It will be important for us to keep track of where else we do this to find out if it's in enough places to just change the template instead as we move forward.  
*To: [Front End Stories](#front-end-stories), [Back End Stories](#back-end-stories)*

### Message Dropdown Cursors
In the site's navbar there is a drop-down that shows new messages from other users. It was configured so the entire drop-down showed a pointer cursor but there were actually only three areas where a user could click to pull up the message. Using the CSS below, I went through and set the whole drop-down to a default cursor, then targeted the three areas (plus the text in the message summary) that a user can click to pull up the messages window. I gave these areas back the pointer cursor so it is easier to see where to click. Finally, I added the text cursor when the user hovers over the search box in the message drop-down to clarify that they can enter text here.

    #message-list, #message-list :hover {
        cursor: default;
    }

    #friendSearch-bar1 :hover {
        cursor: text;
    }

    #message-list .message-item img,
    #message-list .message-item .left-bubble,
    #message-list .message-item .left-bubble p,
    #message-list .message-item .navbar-icon::before {
        cursor: pointer;
    }

*To: [Front End Stories](#front-end-stories), [Back End Stories](#back-end-stories)*
