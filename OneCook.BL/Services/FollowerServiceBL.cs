using System;
using System.Collections.Generic;
using System.Linq;
using OneCook.BL.Services.Interfaces;
using OneCook.DL.Models;
using OneCook.DL.UnitOfWork;
using OneCook.DL.VM.ViewModels;

namespace OneCook.BL.Services
{
    public class FollowerServiceBL : IFollowerServiceBL
    {
        private readonly IUnitOfWork _uow;
        public FollowerServiceBL(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AddFollower(int currentUserId, int userIdToFollow)
        {
            var listId = _uow.FollowerList.FindAll(x => x.UserId == currentUserId).FirstOrDefault();

            if (listId != null)
            {
                if (_uow.Follower.FindAll(x => x.FollowerListId == listId.Id && x.UserFollowingId == userIdToFollow).FirstOrDefault() == null)
                {
                    _uow.Follower.Insert(new Follower
                    {
                        FollowerListId = listId.Id,
                        UserFollowingId = userIdToFollow,
                        CreateDate = DateTime.Now
                    });
                    _uow.Commit();
                }
            }
            else
            {
                var followerList = new FollowerList
                {
                    UserId = currentUserId
                };
                _uow.FollowerList.Insert(followerList);
                _uow.Commit();

                _uow.Follower.Insert(new Follower
                {
                    FollowerListId = followerList.Id,
                    UserFollowingId = userIdToFollow,
                    CreateDate = DateTime.Now
                });
                _uow.Commit();
            }
        }

        public List<UserVM> GetUsersNotFollowing(int currentUserId)
        {
            List<UserVM> usersVM = new List<UserVM>();


            var users = _uow.User.GetBySql($"select u.Id as Id, u.Email as Email, u.[Description] as Description, u.[Password] as Password, u.UserImage as UserImage, u.UserLevelId as UserLevelId, u.Username as Username, u.UserUID as UserUID from users u where Id not in (Select UserFollowingId from Followers where FollowerListId = (Select Id from FollowerLists where UserId = {currentUserId} ))").ToList();


            foreach (var user in users)
            {
                if (user.Id == currentUserId)
                {

                }
                else
                {
                    usersVM.Add(new UserVM(user));
                }
            }
            return usersVM;
        }

        public void StopUserFollow(int currentUserId, int userToUnfollow)
        {
            var followerList = _uow.FollowerList.FindAll(x => x.UserId == currentUserId).FirstOrDefault();

            var followerToUnfollow = _uow.Follower.FindAll(x => x.FollowerListId == followerList.UserId && x.UserFollowingId == userToUnfollow).FirstOrDefault();

            _uow.Follower.Delete(followerToUnfollow);
            _uow.Commit();

        }
    }
}
