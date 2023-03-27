using Microsoft.AspNetCore.Http;
using OneCook.DL.Models;

namespace OneCook.DL.VM.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public int UserLevelId { get; set; }
        public virtual UserLevelVM UserLevel { get; set; }
        public string UserUID { get; set; }
        public string UserImage { get; set; }
        //public IFormFile File { get; set; }

        public UserVM() { }
        public UserVM(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            Password = "";
            Description = user.Description;
            UserLevelId = user.UserLevelId;
            UserUID = user.UserUID;
            UserImage = user.UserImage;
            if (user.UserLevel != null)
            {
                UserLevel = new UserLevelVM(user.UserLevel);
            }
        }

    }
}
