
using OneCook.DL.Models.Custom;

namespace OneCook.DL.VM.ViewModels.Custom
{
    public class MainUserProfileViewVM
    {
        public int Id { get; set; }
        public string RecipeImage { get; set; }
        public string Username { get; set; }
        public string UserDescription { get; set; }
        public string UserImage { get; set; }
        public int Followers { get; set; }
        public int Follows { get; set; }
        public int RecipeNumber { get; set; }

        public MainUserProfileViewVM() { }

        public MainUserProfileViewVM(MainUserProfileView u)
        {
            Id = u.Id;
            RecipeImage = u.RecipeImage;
            Username = u.Username;
            UserDescription = u.UserDescription;
            UserImage = u.UserImage;
            Followers = u.Followers;
            Follows = u.Follows;
            RecipeNumber = u.RecipeNumber;
        }
    }
}
