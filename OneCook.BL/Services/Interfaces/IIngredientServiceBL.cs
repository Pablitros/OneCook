using System.Collections.Generic;
using OneCook.DL.Models;

namespace OneCook.BL.Services.Interfaces
{
    public interface IIngredientServiceBL
    {
        List<IngredientVM> GetIngredientsFromRecipe(int recipeId);
    }
}
