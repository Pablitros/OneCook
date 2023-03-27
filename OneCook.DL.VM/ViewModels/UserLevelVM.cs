using OneCook.DL.Models;

namespace OneCook.DL.VM.ViewModels
{
    public class UserLevelVM
    {
        public int Id { get; set; }
        public string LevelName { get; set; }
        public decimal Price { get; set; }

        public UserLevelVM() { }
        public UserLevelVM(UserLevel userLevel)
        {
            Id = userLevel.Id;
            LevelName = userLevel.LevelName;
            Price = userLevel.Price;
        }

    }
}