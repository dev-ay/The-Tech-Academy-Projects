using Bewander.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bewander.ViewModels
{
    public class AdminFlagViewModel
    {
        // properties

        // Flag properties
        public int FlagID { get; set; }
        public FlagOption FlagStatus { get; set; }
        public DateTime DateFlagged { get; set; }
        public virtual User UserFlagging { get; set; }
        public string UserFlaggingName { get; set; }
        public string UserFlaggingEmail { get; set; }
        public string UserFlaggingProfilePic { get; set; }

        // Who's content is this?
        public string User_ID { get; set; }
        public string ReviewUserName { get; set; }
        public string ReviweUserProfilePic { get; set; }
        public string UserEmail { get; set; }

        // What content is being flagged?
        public string ContentType { get; set; }
        public int? Post_ID { get; set; }
        public int? Review_ID { get; set; }
        public virtual Review Review { get; set; }
        public virtual Post Post { get; set; }
        public string ReviewPicture { get; set; }
        public string ReviewPicturePath { get; set; }

        // constructors

        // empty
        public AdminFlagViewModel() { }

        // for content flagged in reviews
        public AdminFlagViewModel(String contentType, Flag flag, User flaggingUser, String flaggingUserEmail, Image flaggingUserProfilePic, Review review, User user, String userEmail, Image profilePicture, File reviewPicture)
        {
            ContentType = contentType;
            FlagID = flag.FlagID;
            FlagStatus = flag.FlagStatus;
            Post_ID = flag.Post_ID;
            User_ID = user.UserID;
            UserEmail = userEmail;
            Review_ID = review.ReviewID;
            UserFlagging = flaggingUser;
            UserFlaggingName = flaggingUser.FirstName + " " + flaggingUser.LastName;
            UserFlaggingEmail = flaggingUserEmail;
            UserFlaggingProfilePic = (flaggingUserProfilePic.Path != "no-image.png") ? flag.User_ID + "/" + flaggingUserProfilePic.Path : flaggingUserProfilePic.Path;
            DateFlagged = flag.DateFlagged;
            ReviewUserName = user.FirstName + " " + user.LastName;
            ReviewPicture = (reviewPicture == null) ? ReviewPicture = null : ReviewPicture = reviewPicture.Path;
            ReviewPicturePath = (ReviewPicturePath != "no-image.png") ? review.UserID + "/" + ReviewPicture : ReviewPicturePath;
            ReviweUserProfilePic = (profilePicture.Path != "no-image.png") ? review.UserID + "/" + profilePicture.Path : profilePicture.Path;
        }

        // for content flagged in posts
        public AdminFlagViewModel(String contentType, Flag flag, User flaggingUser, String flaggingUserEmail, Image flaggingUserProfilePic, Post post, User user, String userEmail, Image profilePicture, File reviewPicture)
        {
            ContentType = contentType;
            FlagID = flag.FlagID;
            FlagStatus = flag.FlagStatus;
            Review_ID = flag.Review_ID;
            User_ID = user.UserID;
            UserEmail = userEmail;
            Post_ID = post.ID;
            UserFlagging = flaggingUser;
            UserFlaggingName = flaggingUser.FirstName + " " + flaggingUser.LastName;
            UserFlaggingEmail = flaggingUserEmail;
            UserFlaggingProfilePic = (flaggingUserProfilePic.Path != "no-image.png") ? flag.User_ID + "/" + flaggingUserProfilePic.Path : flaggingUserProfilePic.Path;
            DateFlagged = flag.DateFlagged;
            ReviewUserName = user.FirstName + " " + user.LastName;
            ReviewPicture = (reviewPicture == null) ? ReviewPicture = null : ReviewPicture = reviewPicture.Path;
            ReviewPicturePath = (ReviewPicturePath != "no-image.png") ? post.UserID + "/" + ReviewPicture : ReviewPicturePath;
            ReviweUserProfilePic = (profilePicture.Path != "no-image.png") ? post.UserID + "/" + profilePicture.Path : profilePicture.Path;
        }
    }
}
