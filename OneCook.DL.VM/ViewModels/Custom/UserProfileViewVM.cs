using System;
using OneCook.DL.Models.Custom;

namespace OneCook.DL.VM.ViewModels.Custom
{
    public class UserProfileViewVM
    {
        public string Username { get; set; }
        public string UserDescription { get; set; }
        public string UserImage { get; set; }
        public int Followers { get; set; }
        public int Follows { get; set; }
        public string RecipeImage { get; set; }
        public bool AmIFollowing { get; set; }
        public int RecipeNumber { get; set; }

        public UserProfileViewVM() { }
        public UserProfileViewVM(UserProfileView u)
        {
            Username = u.Username;
            UserDescription = u.UserDescription;
            Followers = u.Followers;
            Follows = u.Follows;
            RecipeImage = u.RecipeImage;
            UserImage = u.UserImage;
            RecipeNumber = u.RecipeNumber;
        }
    }
}
