using System;
using OneCook.DL.Models.Custom;

namespace OneCook.DL.VM.ViewModels.Custom
{
    public class CustomRecipeByTimeVM
    {
        public int RecipeId { get; set; }
        public int TimeCreation { get; set; }
        public string Name { get; set; }
        public string RecipeImage { get; set; }
        public int LikeQuantity { get; set; }
        public int RecipeFavorites { get; set; }

        public CustomRecipeByTimeVM(CustomRecipeByTime r)
        {
            RecipeId = r.RecipeId;
            TimeCreation = r.TimeCreation;
            Name = r.Name;
            RecipeImage = r.RecipeImage;
            LikeQuantity = r.LikeQuantity;
            RecipeFavorites = r.RecipeFavorites;
        }
    }
}
