using OneCook.BL.CustomServices.Interfaces;
using OneCook.BL.Services.Interfaces;
using OneCook.DL.Enums;
using OneCook.DL.Models;
using OneCook.DL.VM.ViewModels.Custom;
using OneCook.DL.UnitOfWork;
using OneCook.DL.VM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace OneCook.BL.Services
{
    public class UserServiceBL : IUserServiceBL
    {

        private readonly IUnitOfWork _uow;
        private readonly IStorageService _storageService;

        public UserServiceBL(IUnitOfWork uow, IStorageService storageService)
        //public UserServiceBL(IUnitOfWork uow)
        {
            _uow = uow;
            _storageService = storageService;
        }

        public List<UserVM> GetAll()
        {
            var users = _uow.User.FindAll(null, x => x.UserLevel);
            return users.Select(x => new UserVM(x)).ToList();
        }

        public UserVM GetById(int id)
        {
            var user = _uow.User.FindAll(x => x.Id == id, x => x.UserLevel).FirstOrDefault();
            return new UserVM(user);
        }

        public int? Create(UserVM userVM)
        {
            if (userVM == null)
            {
                throw new Exception("Internal Server error");
            }

            if (_uow.User.FindAll(x => x.Email.ToLower() == userVM.Email.ToLower()) != null)
            {
                User user = new User()
                {
                    Email = userVM.Email,
                    Description = userVM.Description,
                    Password = userVM.Password,
                    UserLevelId = (int)OneCookEnums.UserLevels.Free,
                    Username = userVM.Username,
                    UserUID = userVM.UserUID,
                    UserImage = "https://onecook.blob.core.windows.net/user-profile/DefaultUser.png"
                };
                try
                {
                    // _storageService.UploadFile(user.UserImage, userVM.File);

                    _uow.User.Insert(user);
                    _uow.Commit();
                    return user.Id;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            else
            {
                throw new Exception("The current email already exists");
            }
        }

        public UserVM Login(UserVM userVM)
        {
            if (!String.IsNullOrWhiteSpace(userVM.UserUID))
            {//Login from FireBase with UID check UID AND EMAIL
                if (_uow.User.FindAll(x => x.Email == userVM.Email && x.UserUID == userVM.UserUID).FirstOrDefault() == null)
                {
                    throw new Exception("The current mail and password does not match any of our users");
                }
                else
                {
                    var user = _uow.User.FindAll(x => x.Email == userVM.Email && x.UserUID == userVM.UserUID).FirstOrDefault();
                    user.Password = "";
                    return new UserVM(user);
                }
            }
            else
            {
                if (_uow.User.FindAll(x => x.Email == userVM.Email && x.Password == userVM.Password).FirstOrDefault() == null)
                {
                    throw new Exception("The current mail and password does not match any of our users");
                }
                else
                {
                    var user = _uow.User.FindAll(x => x.Email == userVM.Email && x.Password == userVM.Password).FirstOrDefault();
                    user.Password = "";
                    return new UserVM(user);
                }
            }
        }

        public List<UserVM> GetUsersByName(string name)
        {
            var users = _uow.User.FindAll(x => x.Username.ToLower().Contains(name));
            return users.Select(x => new UserVM(x)).ToList();
        }

        public List<MainUserProfileViewVM> GetUserMainProfileInfo(int userId)
        {
            string sql = $"SELECT r.Id as Id, r.MainImage as RecipeImage, u.UserImage as UserImage, u.UserName as Username, u.[Description] as UserDescription, (Select count(*) from Recipes r where r.UserId = {userId}) as RecipeNumber, (Select count(*) from Followers f where f.FollowerListId = (Select fl.Id from FollowerLists fl where fl.UserId = {userId})) as Follows, (Select COUNT(*) from Followers f where f.UserFollowingId = {userId}) as Followers from recipes r inner join Users u on r.UserId = u.Id where r.UserId = {userId}";

            var query = _uow.MainUserProfileView.GetBySql(sql);

            return query.Select(x => new MainUserProfileViewVM(x)).ToList();
        }

        public List<UserProfileViewVM> GetUserProfileInfo(int userId, int currentUserId)
        {
            string sql = $"SELECT r.MainImage as RecipeImage, u.UserImage as UserImage, u.UserName as Username, u.[Description] as UserDescription, (Select count(*) from Recipes r where r.UserId = {userId}) as RecipeNumber, (Select count(*) from Followers f where f.FollowerListId = (Select fl.Id from FollowerLists fl where fl.UserId = {userId})) as Follows, (Select COUNT(*) from Followers f where f.UserFollowingId = {userId}) as Followers from recipes r inner join Users u on r.UserId = u.Id where r.UserId = {userId}";
            var currentUserList = _uow.FollowerList.FindAll(x => x.UserId == currentUserId).FirstOrDefault();

            if (_uow.Follower.Exists(x => x.FollowerListId == currentUserList.Id && x.UserFollowingId == userId) == true)
            {//AmIFollowing = true
                var query = _uow.UserProfileView.GetBySql(sql);

                var customViews = query.Select(x => new UserProfileViewVM(x)).ToList();

                foreach (var item in customViews)
                {
                    item.AmIFollowing = true;
                }

                return customViews;
            }
            else
            {//AmIFollowing = false
                var query = _uow.UserProfileView.GetBySql(sql);

                var customViews = query.Select(x => new UserProfileViewVM(x)).ToList();

                foreach (var item in customViews)
                {
                    item.AmIFollowing = false;
                }

                return customViews;
            }

        }

        public void UpdateUserImage(IFormFile file, int userId)
        {
            var user = _uow.User.FindAll(x => x.Id == userId).FirstOrDefault();

            if (user != null)
            {
                string userImage = Guid.NewGuid().ToString();
                _storageService.UploadFile(userImage, file);

                user.UserImage = $"https://onecook.blob.core.windows.net/user-profile/{userImage}.png";

                _uow.User.Update(user);
                _uow.Commit();
            }
        }
    }
}
