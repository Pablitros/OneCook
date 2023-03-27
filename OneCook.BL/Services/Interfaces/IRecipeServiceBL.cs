using OneCook.DL.VM.ViewModels;
using OneCook.DL.VM.ViewModels.Custom;
using System.Collections.Generic;

namespace OneCook.BL.Services.Interfaces
{
    public interface IRecipeServiceBL
    {
        void CreateFullRecipe(CreateFullRecipeVM createFullRecipeVM);
        RecipeVM GetRecipeById(int id);
        List<CustomRecipeVM> GetUsersFollowersRecipes(int currentUserId, int skip);
        List<CustomRecipeVM> GetUsersRecipes(int currentUserId);
        List<RecipeVM> GetRecipesByCateogories(List<int> categories);
        List<CustomRecipeByTimeVM> GetRecipesByTime(string time);
    }
}