using System;
using System.Collections.Generic;
using System.Linq;
using OneCook.BL.Services.Interfaces;
using OneCook.DL.Models;
using OneCook.DL.UnitOfWork;

namespace OneCook.BL.Services
{
    public class IngredientServiceBL : IIngredientServiceBL
    {

        private readonly IUnitOfWork _uow;

        public IngredientServiceBL(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<IngredientVM> GetIngredientsFromRecipe(int recipeId)
        {
            var ingredientList = _uow.IngredientList.FindAll(x => x.RecipeId == recipeId).FirstOrDefault();

            if (ingredientList != null)
            {
                var ingredients = _uow.Ingredient.FindAll(x => x.IngredientListId == ingredientList.Id);

                return ingredients.Select(x => new IngredientVM(x)).ToList();
            }
            else
            {
                return null;
            }

        }
    }
}
