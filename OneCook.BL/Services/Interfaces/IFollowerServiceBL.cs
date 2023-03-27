using System.Collections.Generic;
using OneCook.DL.VM.ViewModels;

namespace OneCook.BL.Services.Interfaces
{
    public interface IFollowerServiceBL
    {
        void AddFollower(int currentUserId, int userIdToFollow);
        List<UserVM> GetUsersNotFollowing(int currentUserId);
        void StopUserFollow(int currentUserId, int userToUnfollow);
    }
}
