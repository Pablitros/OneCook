using OneCook.DL.Models;
using OneCook.DL.VM.ViewModels;
using OneCook.DL.VM.ViewModels.Custom;
using System.Collections.Generic;

namespace OneCook.BL.Services.Interfaces
{
    public interface ICategoryServiceBL
    {
        #region Recipes
        //List<RecipeVM> GetRecipes();
        //RecipeVM GetRecipesById(int id);
        //List<RecipeVM> GetUsersFollowersRecipes(int currentUserId, int skip);
        #endregion

        #region Categories
        List<CategoryVM> GetCategories();
        List<RecipeCategoryVM> GetRecipeCategories(int recipeId);
        #endregion
    }
}
