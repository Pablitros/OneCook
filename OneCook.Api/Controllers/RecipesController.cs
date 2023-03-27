using Microsoft.AspNetCore.Mvc;
using OneCook.BL.Services.Interfaces;
using OneCook.DL.VM.ViewModels;
using OneCook.DL.VM.ViewModels.Custom;
using System.Collections.Generic;

namespace OneCook.Api.Controllers
{
    public class RecipesController : ControllerBase
    {

        private IRecipeServiceBL _recipeService;

        public RecipesController(IRecipeServiceBL recipeService)
        {
            _recipeService = recipeService;
        }

        /// <summary>
        /// Get all the recipes from the user followers
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet("/api/Users/{currentUserId}/Recipes")]
        public ActionResult<List<RecipeVM>> GetUsersFollowersRecipes(int currentUserId, [FromQuery] int skip)
        {
            return Ok(_recipeService.GetUsersFollowersRecipes(currentUserId, skip));
        }

        /// <summary>
        /// Gets all the recipes from the user
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        [HttpGet("/api/Recipes")]
        public ActionResult<List<RecipeVM>> GetRecipesFromUser(int currentUserId)
        {
            _recipeService.GetUsersRecipes(currentUserId);
            return Ok();
        }

        /// <summary>
        /// Gets all the recipes that contain any of the listed categories
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        [HttpGet("/api/Recipes/Categories")]
        public ActionResult<List<RecipeVM>> GetRecipesByCategory(List<int> categories)
        {
            var recipes = _recipeService.GetRecipesByCateogories(categories);
            return Ok(recipes);
        }

        /// <summary>
        /// Gets all the recipes by certain time that has most likes and favorites
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        [HttpGet("/api/Recipes/{time}")]
        public ActionResult<List<CustomRecipeByTimeVM>> GetRecipeByTime(string time)
        {
            var recipes = _recipeService.GetRecipesByTime(time);
            return Ok(recipes);
        }

        [HttpGet("/api/Recipe/{id}")]
        public ActionResult<RecipeVM> GetRecipeById(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            return Ok(recipe);
        }

        /// <summary>
        /// Creates a recipe record on the Database
        /// </summary>
        /// <param name="createFullRecipeVM"></param>
        /// <returns></returns>
        [HttpPost("/api/Recipes")]
        public ActionResult CreateFullRecipe([FromBody]CreateFullRecipeVM createFullRecipeVM)
        {
            _recipeService.CreateFullRecipe(createFullRecipeVM);
            return NoContent();
        }

    }
}
