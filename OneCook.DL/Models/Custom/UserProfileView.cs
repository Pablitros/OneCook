using System;
namespace OneCook.DL.Models.Custom
{
    public class UserProfileView
    {
        public string Username { get; set; }
        public string UserDescription { get; set; }
        public int Followers { get; set; }
        public int Follows { get; set; }
        public string RecipeImage { get; set; }
        public string UserImage { get; set; }
        public int RecipeNumber { get; set; }
    }
}
