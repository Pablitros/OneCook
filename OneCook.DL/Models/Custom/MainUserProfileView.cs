using System;
namespace OneCook.DL.Models.Custom
{
    public class MainUserProfileView
    {
        public int Id { get; set; }
        public string RecipeImage { get; set; }
        public string Username { get; set; }
        public string UserDescription { get; set; }
        public string UserImage { get; set; }
        public int Followers { get; set; }
        public int Follows { get; set; }
        public int RecipeNumber { get; set; }
    }
}
