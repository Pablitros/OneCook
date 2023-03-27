using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneCook.BL.Services.Interfaces;
using OneCook.DL.Models;
using OneCook.DL.VM.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OneCook.Api.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IFavoriteServiceBL _favoriteService;

        public FavoritesController(IFavoriteServiceBL favoriteServiceBL)
        {
            _favoriteService = favoriteServiceBL;
        }


        /// <summary>
        /// List user's favorite recipes
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("/api/Users/{userId}/Recipes/Favorites")]
        public ActionResult<List<FavoriteVM>> ListUserFavoriteRecipe(int userId)
        {
            var favRecipes = _favoriteService.GetUserFavoriteRecipes(userId);

            return Ok(favRecipes);
        }

        /// <summary>
        /// Adds the recipe to the current user's favorites list
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpPost("/api/users/{userId}/recipes/{recipeId}/favorites")]
        public ActionResult AddRecipeToFavories(int userId, int recipeId)
        {
            _favoriteService.AddRecipeToFavorite(recipeId, userId);
            return Ok();
        }

        /// <summary>
        /// Deletes recipe from currrent user's favorite recipe list
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpDelete("/api/users/{userId}/recipes/{recipeId}/favorites")]
        public ActionResult RemoveRecipeFromFavories(int userId, int recipeId)
        {
            _favoriteService.RemoveRecipeFromFavories(recipeId, userId);
            return Ok();
        }
    }
}
