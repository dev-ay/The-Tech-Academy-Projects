using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Bewander.DAL;
using Bewander.Models;
using Bewander.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using System.Text;
using System.Data.SqlClient;

namespace Bewander.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext ac = new ApplicationDbContext();
        private static BewanderContext bc = new BewanderContext();

        // GET: Admin
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            return View (new AdminUserViewModel());

        }

        /*
        this generates the table based on the search criteria given from the form on the index page.
        the search variables will hold data based on what the admin wants to search users by.
        the Filter variables are used to hold/store the search variables when a page change is made, this way you don't
        lose the search criteria when you change to another page of the table.
        */
        public PartialViewResult _UserSearchResults(
            string sortOrder, 
            string nameFilter, string hometownFilter, string daysFilter, string lockedOutFilter, string rolesFilter,
            string searchName, string searchHometown, string searchDays, string searchLockedOut, string searchRoles,
            int? page)
        {
        // Tanvir(23/12/16): Creating Paged List
            ViewBag.CurrentSort = sortOrder;
            ApplicationDbContext acSearchResults = new ApplicationDbContext();
            BewanderContext bcSearchResults = new BewanderContext();

            var Users = from u in bcSearchResults.Users select u;
            var Places = from p in bcSearchResults.Places select p;
            int maxDays = 0;
            
            //these if's are needed to reset the page to 1 should the search criteria change while on a page other than 1
            //I believe you need one for each search criteria
            if (searchName != null)
            {
                page = 1;
            }
            else
            {
                searchName = nameFilter;
            }
            ViewBag.nameFilter = searchName;
            if(searchHometown != null)
            {
                page = 1;
            }
            else
            {
                searchHometown = hometownFilter;
            }
            ViewBag.hometownFilter = searchHometown;
            if(searchDays != null)
            {
                page = 1;
            }
            else
            {
                searchDays = daysFilter;
            }
            ViewBag.daysFilter = searchDays;
            if(searchLockedOut != null){
                page = 1;
            }
            else
            {
                searchLockedOut = lockedOutFilter;
            }
            ViewBag.lockedOutFilter = searchLockedOut;
            if(searchRoles != null)
            {
                page = 1;
            }
            else
            {
                searchRoles = rolesFilter;
            }
            ViewBag.rolesFilter = searchRoles;
            if (!String.IsNullOrEmpty(searchName))
            {
                Users = Users.Where(u => u.LastName.ToLower().Contains(searchName.ToLower()) || u.FirstName.ToLower().Contains(searchName.ToLower()));
            }

            if (!String.IsNullOrEmpty(searchHometown))
            {
                Places = Places.Where(p => p.Name.ToLower().Contains(searchHometown.ToLower()));
            }

            if (!String.IsNullOrEmpty(searchDays))
            {
                maxDays = int.Parse(searchDays);
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            // End of PagedList


            // Create ViewModel to run list function
            AdminSearchViewModel vm = new AdminSearchViewModel();
            // Assemble lists to be passed to list function
            List<AdminSearchViewModel> viewModels = new List<AdminSearchViewModel>();
            List<ApplicationUser> applicationUsers = acSearchResults.Users.ToList();
            List<User> users = Users.ToList();
            List<UserProfile> userProfiles = bcSearchResults.UserProfiles.ToList();
            List<Place> places = Places.ToList();
            List<Review> reviews = bcSearchResults.Reviews.ToList();
            List<Post> posts = bcSearchResults.Posts.ToList();
            //pass data to list function
            vm.AdminSearchList(viewModels,
             users,
             userProfiles,
             places,
             applicationUsers,
             posts,
             reviews,
             searchHometown,
             maxDays,
             searchLockedOut,
             searchRoles
             );
            // for each viewModel, convert Id hash store in Role to name of role
            foreach (AdminSearchViewModel viewModel in viewModels)
            {
                viewModel.Role = acSearchResults.Roles.Where(a => a.Id == viewModel.Role).Select(a => a.Name).FirstOrDefault();
            }

            //SORTING CODE HERE
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DaysSort = sortOrder == "Days" ? "days_desc" : "Days";
            ViewBag.HometownSort = String.IsNullOrEmpty(sortOrder) ? "hometown_desc" : "";
            ViewBag.FlaggedPostSort = sortOrder == "Flagged Posts" ? "flagged_post_desc" : "Flagged Posts";
            ViewBag.LockedOutSort = sortOrder == "Locked Out" ? "locked_out_desc" : "Locked Out";
            ViewBag.RolesSort = sortOrder == "Roles" ? "roles_desc" : "Roles";

            switch (sortOrder)
            {
                case "name_desc":
                    viewModels = viewModels.OrderByDescending(v => v.LastName).ToList();
                    break;
                case "Days":
                    viewModels = viewModels.OrderBy(v => v.DaysAsMember).ToList();
                    break;
                case "days_desc":
                    viewModels = viewModels.OrderByDescending(v => v.DaysAsMember).ToList();
                    break;
                case "hometown_desc":
                    viewModels = viewModels.OrderByDescending(v => v.HomeTownName).ToList();
                    break;
                case "Flagged Posts":
                    viewModels = viewModels.OrderBy(v => v.PostFlag).ToList();
                    break;
                case "flagged_post_desc":
                    viewModels = viewModels.OrderByDescending(v => v.PostFlag).ToList();
                    break;
                case "Locked Out":
                    viewModels = viewModels.OrderBy(v => v.LockOutEnabled).ToList();
                    break;
                case "locked_out_desc":
                    viewModels = viewModels.OrderByDescending(v => v.LockOutEnabled).ToList();
                    break;
                case "Roles":
                    viewModels = viewModels.OrderBy(v => v.Role).ToList();
                    break;
                case "roles_desc":
                    viewModels = viewModels.OrderByDescending(v => v.Role).ToList();
                    break;
                default:
                    viewModels = viewModels.OrderBy(v => v.LastName).ToList();
                    break;
            }
            //END OF SORTING CODE

            //these need to be here, you get connection to DB issue otherwise
            acSearchResults.Dispose();
            bcSearchResults.Dispose();

            //if there are no results, display the PartialView for that. 
            if(viewModels.Count == 0)
            {
                return PartialView("_UserSearchNoResults");
            }
            else //otherwise displays PartialView with results from search
            {
                return PartialView("_UserSearchResults", viewModels.ToPagedList(pageNumber, pageSize));
            }
        }


        // Function to download user info .csv file
        public void DownloadCsv()
		{
			var Users = from u in bc.Users
						select u;
			AdminUserViewModel vm = new AdminUserViewModel();
			List<AdminUserViewModel> viewModels = new List<AdminUserViewModel>();
			List<ApplicationUser> applicationUsers = ac.Users.ToList();
			List<User> users = Users.ToList();
			List<UserProfile> userProfiles = bc.UserProfiles.ToList();
			List<Place> places = bc.Places.ToList();
			List<Review> reviews = bc.Reviews.ToList();
			List<Post> posts = bc.Posts.ToList();
            List<Flag> flags = bc.Flags.ToList();
            //pass data to list function
            vm.AdminUserList(
             viewModels,
             users,
             userProfiles,
             places,
             applicationUsers,
             posts,
             flags,
             reviews
             );
			string usersCsv = GetCsvString(viewModels);

			// return file content with response body
			Response.ContentType = "text/csv";
			Response.AddHeader("Content-Disposition", "attachment;filename=Users.csv");
			Response.Write(usersCsv);
			Response.End();
		}
		
		// Function to create .csv of all user email addresses
		public string GetCsvString(List<AdminUserViewModel> users)
		{
			StringBuilder csv = new StringBuilder();
			foreach (AdminUserViewModel user in users)
			{
				csv.Append(user.Email + ",");
			}
			csv.Length--;
			return csv.ToString();
		}

		// GET: Admin/Edit/5
		public ActionResult Edit(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // assemble AdminUserViewModel for passed Id
            ApplicationUser appUser = ac.Users.Where(a => a.Id == Id).FirstOrDefault();
            User person = bc.Users.Where(a => a.UserID == Id).FirstOrDefault();
            UserProfile profile = bc.UserProfiles.Where(a => a.UserID == Id).FirstOrDefault();

            // gets RoleId from user data and converts to role name
            string roleId = appUser.Roles.Where(a => a.UserId == Id).Select(a => a.RoleId).FirstOrDefault();
            string roleName = ac.Roles.Where(a => a.Id == roleId).Select(a => a.Name).FirstOrDefault();

            // gets first entry from favorite places - Linq does not like Split
            string favPlace = (profile.FavoritePlace ?? "BLAH").Split(',')[0];
            string place = bc.Places.Where(a => a.PlaceID == favPlace).Select(a => a.Name).FirstOrDefault() ?? "N/A";
            string homeTown = bc.Places.Where(a => a.PlaceID == profile.HomeTown).Select(a => a.Name).FirstOrDefault() ?? "N/A";

            //counts number of flagged submissions by type. Flags have been converted to a table.
            int postFlag = bc.Flags.Count(a => a.Post.UserID == Id);
            int reviewFlag = bc.Flags.Count(a => a.Review.UserID == Id);
            //int reviewFlag = bc.Reviews.Count(a => a.UserID == Id && a.Flag > 0);

            bool lockOutEnabled = appUser.LockoutEnabled;

            AdminUserViewModel vm = new AdminUserViewModel(appUser, person, profile, roleName, place, homeTown, postFlag, reviewFlag);

            return View(vm);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdminUserViewModel vm)
        {                 
            if (ModelState.IsValid)
            {
                // Saves relevant lockout and role data to the database
                ApplicationUser user = ac.Users.Where(a => a.Id == vm.Id).First();

                string rid = user.Roles.Where(a => a.UserId == vm.Id).Select(a => a.RoleId).FirstOrDefault();
                string role = ac.Roles.Where(a => a.Id == rid).Select(a => a.Name).FirstOrDefault() ?? "no role";
                // only remove current role and add new role if admin has changed role 
                if(role != vm.Role)
                {
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ac));
                    var result1 = userManager.RemoveFromRole(vm.Id, role);
                    var result2 = userManager.AddToRole(vm.Id, vm.Role);
                }
                if (vm.LockOutEnabled)
                {
                    //Over ride the time of day user input (hours minutes seconds)
                    //This allows admin bans to only allow one time of day (1:37:59) to be used for admin applied bans
                    //That allows us to implement other features without database migration
                    //To get rid of this code, change LockoutEnabled from a bool (true / false) to an integer, with 0 = no ban, 1 = admin ban, 2 = automatic ban
                    //And then change other code as necessary. 
                    DateTime originaltime = vm.LockOutEndDate; //store the admin selection time
                    DateTime admintime = new DateTime(1992, 5, 22, 1, 37, 59); //2012 , 2 , 4 are irrelevant since .TimeOfDay method is used below. 1, 37, 59 = 1:37:59
                    DateTime modifiedDates = originaltime.Date.Add(admintime.TimeOfDay); //Change the Time Of Day (hours minutes seconds) to 1:37:59.

                    user.LockoutEnabled = vm.LockOutEnabled;
                    user.LockoutEndDateUtc = modifiedDates;
                }
                else
                {
                    user.LockoutEnabled = vm.LockOutEnabled;
                    user.LockoutEndDateUtc = vm.LockOutEndDate.AddHours(1);//removes the custom lockout flag
                }
                

                // store changes in database
                ac.Entry(user).State = EntityState.Modified;
                ac.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

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

        // GET: Admin/Delete/5
        public ActionResult DeleteUser(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			User user = bc.Users.SqlQuery("dbo.User_Select @p0", id).SingleOrDefault();
			if (user == null)
			{
				return HttpNotFound();
			}
			return View(user);
		}

		// POST: Admin/Delete/5
		[HttpPost, ActionName("DeleteUser")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteUserConfirmed(string id)
		{
			// open the data connection
			using (SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\User\\Source\\Workspaces\\Workspace\\Bewander\\Bewander\\App_Data\\Bewander.mdf; Integrated Security = True"))
			{
				// disable the foreign key constraints preventing user deletion
				SqlCommand disableConstraint1 = new SqlCommand("ALTER TABLE [Like] NOCHECK CONSTRAINT [FK_dbo.Like_dbo.Comment_Comment_ID]", con);
				con.Open();
				disableConstraint1.ExecuteNonQuery();

				SqlCommand disableConstraint2 = new SqlCommand("ALTER TABLE [Like] NOCHECK CONSTRAINT [FK_dbo.Like_dbo.Post_Post_ID]", con);
				disableConstraint2.ExecuteNonQuery();

				// delete all records connected to the user
				SqlCommand cmd1 = new SqlCommand("DELETE FROM [Like] WHERE UserID = @id", con);
				cmd1.Parameters.AddWithValue("@id", id);
				cmd1.ExecuteNonQuery();

				SqlCommand cmd2 = new SqlCommand("DELETE FROM dbo.Comment WHERE User_UserID = @id", con);
				cmd2.Parameters.AddWithValue("@id", id);
				cmd2.ExecuteNonQuery();

				SqlCommand cmd3 = new SqlCommand("DELETE FROM dbo.Post WHERE UserID = @id", con);
				cmd3.Parameters.AddWithValue("@id", id);
				cmd3.ExecuteNonQuery();

				SqlCommand cmd4 = new SqlCommand("DELETE FROM [File] WHERE UserID = @id", con);
				cmd4.Parameters.AddWithValue("@id", id);
				cmd4.ExecuteNonQuery();

				SqlCommand cmd5 = new SqlCommand("DELETE FROM [Review] WHERE UserID = @id", con);
				cmd5.Parameters.AddWithValue("@id", id);
				cmd5.ExecuteNonQuery();

				// delete the user
				SqlCommand cmd6 = new SqlCommand("DELETE FROM [User] WHERE UserID = @id", con);
				cmd6.Parameters.AddWithValue("@id", id);
				cmd6.ExecuteNonQuery();

				// reenable the foreign key constraints preventing user deletion
				SqlCommand reenableConstraint1 = new SqlCommand("ALTER TABLE [Like] WITH CHECK CHECK CONSTRAINT [FK_dbo.Like_dbo.Comment_Comment_ID]", con);
				disableConstraint1.ExecuteNonQuery();

				SqlCommand reenableConstraint2 = new SqlCommand("ALTER TABLE [Like] WITH CHECK CHECK CONSTRAINT [FK_dbo.Like_dbo.Post_Post_ID]", con);
				disableConstraint2.ExecuteNonQuery();
			}
			bc.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ac.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
