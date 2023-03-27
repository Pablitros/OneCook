using System;
namespace OneCook.DL.Models.Custom
{
    public class CustomRecipeByTime
    {
        public int RecipeId { get; set; }
        public int TimeCreation { get; set; }
        public string Name { get; set; }
        public string RecipeImage { get; set; }
        public int LikeQuantity { get; set; }
        public int RecipeFavorites { get; set; }
    }
}
