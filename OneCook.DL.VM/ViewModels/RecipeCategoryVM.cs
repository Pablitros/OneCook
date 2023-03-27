using OneCook.DL.VM.ViewModels;

namespace OneCook.DL.Models
{
    public class RecipeCategoryVM
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryVM Category { get; set; }
        public virtual RecipeVM Recipe { get; set; }

        public RecipeCategoryVM() { }
        public RecipeCategoryVM(RecipeCategory recipeCategory)
        {
            Id = recipeCategory.Id;
            RecipeId = recipeCategory.RecipeId;
            CategoryId = recipeCategory.CategoryId;
            if (recipeCategory.Category != null)
            {
                Category = new CategoryVM(recipeCategory.Category);
            }
            if (recipeCategory.Recipe != null)
            {
                Recipe = new RecipeVM(recipeCategory.Recipe);
            }
        }

    }
}
