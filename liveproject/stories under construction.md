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