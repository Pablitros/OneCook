using OneCook.DL.VM.ViewModels;

namespace OneCook.DL.Models
{
    public class FollowerVM
    {
        public int Id { get; set; }
        public int FollowerListId { get; set; }

        public int UserFollowingId { get; set; }

        public virtual UserVM User { get; set; }
        public virtual FollowerListVM FollowerList { get; set; }

        public FollowerVM() { }
        public FollowerVM(Follower follower)
        {
            Id = follower.Id;
            FollowerListId = follower.FollowerListId;
            UserFollowingId = follower.UserFollowingId;
            if (follower.User != null)
            {
                User = new UserVM(follower.User);
            }
            if (follower.FollowerList != null)
            {
                FollowerList = new FollowerListVM(follower.FollowerList);
            }
        }
    }
}
