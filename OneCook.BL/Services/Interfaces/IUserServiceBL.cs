using OneCook.DL.VM.ViewModels.Custom;
using OneCook.DL.VM.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace OneCook.BL.Services.Interfaces
{
    public interface IUserServiceBL
    {
        List<UserVM> GetAll();
        UserVM GetById(int id);
        int? Create(UserVM usersVM);
        List<UserVM> GetUsersByName(string name);
        List<MainUserProfileViewVM> GetUserMainProfileInfo(int userId);
        List<UserProfileViewVM> GetUserProfileInfo(int userId, int currentUserId);
        UserVM Login(UserVM userVM);
        void UpdateUserImage(IFormFile file, int userId);
    }
}
