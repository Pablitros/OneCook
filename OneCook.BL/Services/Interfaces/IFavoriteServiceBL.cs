using System.Collections.Generic;
using OneCook.DL.Models;

namespace OneCook.BL.Services.Interfaces
{
    public interface IFavoriteServiceBL
    {
        void AddRecipeToFavorite(int recipeId, int userId);
        List<FavoriteVM> GetUserFavoriteRecipes(int userId);
        void RemoveRecipeFromFavories(int recipeId, int userId);
    }
}
