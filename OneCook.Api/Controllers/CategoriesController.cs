using Microsoft.AspNetCore.Mvc;
using OneCook.BL.Services.Interfaces;
using OneCook.DL.Models;
using OneCook.DL.VM.ViewModels;
using OneCook.DL.VM.ViewModels.Custom;
using System.Collections.Generic;

namespace OneCook.Api.Controllers
{
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryServiceBL _categoryService;
        public CategoriesController(ICategoryServiceBL categoryService)
        {
            _categoryService = categoryService;
        }


        /// <summary>
        /// Returns list of all the categories
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/Categories")]
        public ActionResult<List<CategoryVM>> Get()
        {
            return Ok(_categoryService.GetCategories());
        }

        //[HttpGet("/api/Categories/{id}")]
        //public ActionResult<RecipeVM> GetById(int id)
        //{
        //    return Ok(_categoryService.GetById(id));
        //}

        //[HttpGet("/api/Users/{currentUserId}/Recipes")]
        //public ActionResult<List<RecipeVM>> GetUsersFollowersRecipes(int currentUserId, [FromQuery] int skip)
        //{
        //    return Ok(_categoryService.GetUsersFollowersRecipes(currentUserId, skip));
        //}

        [HttpGet("/api/recipes/{recipeId}/categories")]
        public ActionResult<List<RecipeCategoryVM>> GetRecipeCategories(int recipeId)
        {
            var recipeCategories = _categoryService.GetRecipeCategories(recipeId);
            return Ok(recipeCategories);
        }
    }
}
