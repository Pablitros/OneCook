using OneCook.DL.Models;
using System;

namespace OneCook.DL.VM.ViewModels
{
    public class IngredientListVM
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public DateTime CreateDate { get; set; }
        public RecipeVM Recipe { get; set; }

        public IngredientListVM() { }
        public IngredientListVM(IngredientList ingredientList)
        {
            Id = ingredientList.Id;
            RecipeId = ingredientList.RecipeId;
            CreateDate = ingredientList.CreateDate;
            if (ingredientList.Recipe != null)
            {
                Recipe = new RecipeVM(ingredientList.Recipe);
            }
        }
    }
}
