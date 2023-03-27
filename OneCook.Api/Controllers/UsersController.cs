using Microsoft.AspNetCore.Mvc;
using OneCook.BL.Services.Interfaces;
using OneCook.DL.VM.ViewModels.Custom;
using OneCook.DL.VM.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace OneCook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserServiceBL _userService;

        public UsersController(IUserServiceBL userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gest all users records from Database
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/users")]
        public ActionResult<List<UserVM>> GetAll()
        {
            return Ok(_userService.GetAll());
        }

        /// <summary>
        /// Gets user by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet("{id}")]
        //public ActionResult<UserVM> GetById(int id)
        //{
        //    return Ok(_userService.GetById(id));
        //}

        /// <summary>
        /// Custom filter for users by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("/api/users/{username}")]
        public ActionResult<List<UserVM>> GetUsersByUseranme(string username)
        {
            return Ok(_userService.GetUsersByName(username));
        }


        /// <summary>
        /// Gets the data for the main profile of the current user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("/api/users/{userId}/main-profile")]
        public ActionResult<MainUserProfileViewVM> GetUserInfo(int userId)
        {
            return Ok(_userService.GetUserMainProfileInfo(userId));
        }

        /// <summary>
        /// Creates new User
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public ActionResult<int?> Create(UserVM user)
        {
            return Ok(_userService.Create(user));
        }


        /// <summary>
        /// Checks if the user exists on the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("/api/users/login")]
        public ActionResult<UserVM> Login(UserVM user)
        {
            return Ok(_userService.Login(user));
        }

        /// <summary>
        /// Updates the user image
        /// </summary>
        /// <param name="file"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPut("/api/users/{userId}")]
        public ActionResult UpdateUserImage(IFormFile file, int userId)
        {
            _userService.UpdateUserImage(file, userId);
            return NoContent();
        }
    }
}
