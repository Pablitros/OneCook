using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneCook.BL.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OneCook.Api.Controllers
{
    public class LikesController : Controller
    {
        private readonly ILikeServiceBL _likeService;

        public LikesController(ILikeServiceBL likeService)
        {
            _likeService = likeService;
        }

        /// <summary>
        /// Adds like to recipe with the user Id and the recipe Id
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="userId"></param>
        [HttpPost("/api/Recipes/{recipeId}/Users/{userId}/Like")]
        public void LikeRecipe(int recipeId, int userId)
        {
            _likeService.LikePost(recipeId, userId);
        }

        /// <summary>
        /// Removes like from recipe by the id of the recipe
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="userId"></param>
        [HttpDelete("/api/Recipes/{recipeId}/Users/{userId}/Like")]
        public void RemoveLikeFromRecipe(int recipeId, int userId)
        {
            _likeService.RemoveLike(recipeId, userId);
        }
    }
}
