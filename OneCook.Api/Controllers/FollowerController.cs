using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneCook.BL.Services.Interfaces;
using OneCook.DL.VM.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OneCook.Api.Controllers
{
    public class FollowerController : Controller
    {
        private readonly IFollowerServiceBL _followerService;

        public FollowerController(IFollowerServiceBL followerService)
        {
            _followerService = followerService;
        }

        /// <summary>
        /// Adds follower 
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <param name="userIdToFollow"></param>
        [HttpPost("/api/users/{currentUserId}/follow/{userIdToFollow}")]
        public void AddFollower(int currentUserId, int userIdToFollow)
        {
            _followerService.AddFollower(currentUserId, userIdToFollow);
        }

        /// <summary>
        /// Gets all the user's the user is not currently following
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        [HttpPost("/api/users/{currentUserId}/follow")]
        public ActionResult<List<UserVM>> GetUsersNotFollowing(int currentUserId)
        {
            var users = _followerService.GetUsersNotFollowing(currentUserId);

            return Ok(users);
        }

        [HttpDelete("/api/users/{currentUserId}/follow/{userToUnfollow}")]
        public ActionResult StopUserFollow(int currentUserId, int userToUnfollow)
        {
            _followerService.StopUserFollow(currentUserId, userToUnfollow);
            return NoContent();
        }
    }
}
