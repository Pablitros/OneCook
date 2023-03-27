using OneCook.DL.Models;
using System.Collections.Generic;

namespace OneCook.DL.VM.ViewModels.Custom
{
    public class CreateFullRecipeVM
    {
        public RecipeVM Recipe { get; set; }//done
        public List<RecipeCategoryVM> RecipeCategory { get; set; }//done
        public List<IngredientVM> Ingredients { get; set; }//done
        public List<ImageVM> Images { get; set; }//done
        public List<StepVM> Steps { get; set; }//done
    }
}
