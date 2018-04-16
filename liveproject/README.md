# Live Project

## Introduction
For my final project at The Tech Academy, I worked with a development team of my peers on a full-scale social media/traveling app in C#. It was a great opportunity to take on a legacy code base, see how the code was laid out, fix bugs, and add requested features. I saw first-hand how an app can evolve over time and outgrow some of the early choices the original developers made while building it. When changing direction on big decisions would require a larger rewrite that the client does not have time for, I saw how good developers can pick up what was there and make the best of the situation to deliver a quality product. We worked together as a team to learn the quirks of how the application was first written and how we could work within those constraints to still deliver the desired what was asked of us.

## Stories I Worked On

### Change Button Font Color
When it comes to picking up large code bases, I like starting with specific tasks in the actual code like tracing a specific functionality I know I will be working with, or finding where a bug is occuring. I find this helps me understand how the original developers built out the app and where to look for different things in the project structure. With this in mind, the first story I took was to update the font color of the button users click to submit reviews for a location they've traveled to. Though this sounds simple, I actually ran into a problem off the bat--the project had some style written in SASS and some in CSS, and there were often several overlapping targets for the same element. This meant the first place I thought to look for the change wasn't right and I had to keep tracing the places where previous developers had targeted the same ID to find what was taking precedence and make my change there.

### Change Header Tags
While I was working with Aja to troubleshoot the more complex user story described below, I completed a different user story requiring a change to a view partial so that the h3 and h1 tags are attached to the correct elements. The challenge with this story was that the change needed to occur on a page where the database in development did not have access to the images the ViewModel was asking for (to pass to the View.) This caused the app to error out when a user navigated to the page to see the updated html. Because the ViewModel C# code works in production, I went around this by passing in an empty string for the image path so that the page could load without images and display my html changes and confirm I had completed the changes the story requested.

### Modify AdminUserViewModel
With the CSS story under my belt and some idea of the types of problem solving this project was going to require, I next took on a more challenging story that involved modifying a ViewModel to update it's properties and create a constructor.
 When I tried to update the properties and constructor, I ran into some errors because the way I was getting the information in the constructor caused Visual Studio to think I was trying to update the model. Because the project was code-first, it wanted me to run a migration to update the model so the database could reflect the most current structure.
 *Still working on this story*

#### Notes:
ASSIGNMENT:
Modify the AdminUserViewModel to remove the PostFlag and ReviewFlag properties and replace them with the following properties from the Flag model:
* string id of user who posted the flagged item
* string id of user who flagged the item
* Enum FlagOption FlagStatus
* string path for the image associated with the post
* DateTime DateFlagged
Then create a constructor to create an AdminUserViewModel with these properties.
  
   // from Flag table
   public string PostedUserID { get; set; }
   public string FlaggedUserID { get; set; }
   public FlagOption FlagStatus { get; set; }
   public string PostImagePath { get; set; }
   public DateTime DateFlagged { get; set; }


   public AdminUserViewModel(User user, Flag flag)
   {
       PostedUserID = user.UserID;
       User_ID = flag.User_ID;
       FlagStatus = flag.FlagStatus;
       //PostImagePath = post.PhotoID;
       DateFlagged = flag.DateFlagged;
   }
  
Progress:
* added properties
* created constructor outline
  
Questions:
* constructor with just these properties? *yes*
* If I am replacing PostFlag and ReviewFlag, should I chase down all the other areas these are used to replace with the new properties? *yes, make sure to note where you removed references*
* does anything else go in my constructor? *nope!*
* build error suggesting migration as soon as I modify AdminUserViewModel? *currently working on with Aja*

#### Notes:
Because this is a code-first project, when the database changes we need to create a migration. This is a snapshot of the changes to the database structure. To do this, in package manager console run:
* add-migration
* update-database