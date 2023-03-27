using OneCook.DL.VM.ViewModels;

namespace OneCook.DL.Models
{
    public class FollowerListVM
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Es el usuario que tiene los seguidores (Como si fuese un perfil de usuario)
        public virtual UserVM User { get; set; }

        public FollowerListVM() { }
        public FollowerListVM(FollowerList followerList)
        {
            Id = followerList.Id;
            UserId = followerList.UserId;
            if (followerList.User != null)
            {
                User = new UserVM(followerList.User);
            }

        }
    }
}
