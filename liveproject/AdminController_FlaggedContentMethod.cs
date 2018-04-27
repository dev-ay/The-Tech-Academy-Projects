public ActionResult FlaggedContent(string sortOrder, string searchString)
{
    // sorting by:
    // type of flagged content
    // name of person flagging
    // name of person posting the content
    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "user_name_dec" : "";
    ViewBag.TypeSortParm = sortOrder == "type" ? "type_desc" : "type";
    ViewBag.FlaggingUserSortParm = sortOrder == "flagging_user_name" ? "flagging_user_name_desc" : "flagging_user_name";

    User thisUser;
    Review thisReview;
    Post thisPost;
    File reviewImage;
    String flaggingUserEmail;
    String userEmail;
    User flaggingUser;
    List<AdminFlagViewModel> flagged = new List<AdminFlagViewModel>();

    foreach (var flag in bc.Flags.ToList())
    {
        if (bc.Reviews.SqlQuery("dbo.Review_Select @p0", flag.Review_ID).SingleOrDefault() != null)
        {
            string contentType = "Review";
            thisReview = bc.Reviews.SqlQuery("dbo.Review_Select @p0", flag.Review_ID).SingleOrDefault();
            reviewImage = bc.Files.SqlQuery("SELECT * FROM [dbo].[File] WHERE ID = @p0", thisReview.ImageID).SingleOrDefault();

            thisUser = thisReview.User;
            userEmail = ac.Users.Where(a => a.Id == thisReview.UserID).Select(a => a.Email).FirstOrDefault();
            Image profilePicture = Image.GetProfileImages(thisUser.UserID, FileType.ProfilePicture);

            flaggingUserEmail = ac.Users.Where(a => a.Id == flag.User_ID).Select(a => a.Email).FirstOrDefault();
            flaggingUser = bc.Users.SqlQuery("SELECT * FROM [dbo].[User] WHERE UserID = @p0", flag.User_ID).SingleOrDefault();
            Image flaggingUserProfilePicture = Image.GetProfileImages(flaggingUser.UserID, FileType.ProfilePicture);
            AdminFlagViewModel items = new AdminFlagViewModel(contentType, flag, flaggingUser, flaggingUserEmail, flaggingUserProfilePicture, thisReview, thisUser, userEmail, profilePicture, reviewImage);
            flagged.Add(items);
        }

        if (bc.Posts.SqlQuery("SELECT * FROM [dbo].[Post] WHERE ID = @p0", flag.Post_ID).SingleOrDefault() != null)
        {
            string contentType = "Post";
            thisPost = bc.Posts.SqlQuery("SELECT * FROM [dbo].[Post] WHERE ID = @p0", flag.Post_ID).SingleOrDefault();
            reviewImage = bc.Files.SqlQuery("SELECT * FROM [dbo].[File] WHERE ID = @p0", thisPost.PhotoID).SingleOrDefault();

            thisUser = thisPost.User;
            userEmail = ac.Users.Where(a => a.Id == thisPost.UserID).Select(a => a.Email).FirstOrDefault();
            Image profilePicture = Image.GetProfileImages(thisUser.UserID, FileType.ProfilePicture);

            flaggingUserEmail = ac.Users.Where(a => a.Id == flag.User_ID).Select(a => a.Email).FirstOrDefault();
            flaggingUser = bc.Users.SqlQuery("SELECT * FROM [dbo].[User] WHERE UserID = @p0", flag.User_ID).SingleOrDefault();
            Image flaggingUserProfilePicture = Image.GetProfileImages(flaggingUser.UserID, FileType.ProfilePicture);
            AdminFlagViewModel items = new AdminFlagViewModel(contentType, flag, flaggingUser, flaggingUserEmail, flaggingUserProfilePicture, thisPost, thisUser, userEmail, profilePicture, reviewImage);
            flagged.Add(items);
        }
    }
    var flaggedList = from s in flagged
                        select s;
    if (!String.IsNullOrEmpty(searchString))
    {
        flaggedList = flaggedList.Where(s => s.ReviewUserName.ToLower().Contains(searchString.ToLower())
                                        || s.UserFlaggingName.ToLower().Contains(searchString.ToLower())
                                        || s.ContentType.ToLower().Contains(searchString.ToLower()));
    }

    switch (sortOrder)
    {
        case "user_name_dec":
            flaggedList = flaggedList.OrderByDescending(s => s.ReviewUserName);
            break;
        case "flagging_user_name":
            flaggedList = flaggedList.OrderBy(s => s.UserFlaggingName);
            break;
        case "flagging_user_name_desc":
            flaggedList = flaggedList.OrderByDescending(s => s.UserFlaggingName);
            break;
        case "type":
            flaggedList = flaggedList.OrderBy(s => s.ContentType);
            break;
        case "type_desc":
            flaggedList = flaggedList.OrderByDescending(s => s.ContentType);
            break;
        default:
            flaggedList = flaggedList.OrderBy(s => s.ReviewUserName);
            break;
    }

    //return View(flagged);
    return View(flaggedList);
}