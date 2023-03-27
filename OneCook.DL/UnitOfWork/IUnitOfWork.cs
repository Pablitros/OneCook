using OneCook.DL.Models;
using OneCook.DL.Models.Custom;
using OneCook.DL.Repository;

namespace OneCook.DL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Category> Category { get; }
        IRepository<Comment> Comment { get; }
        IRepository<Favorite> Favorite { get; }
        IRepository<Follower> Follower { get; }
        IRepository<FollowerList> FollowerList { get; }
        IRepository<Image> Image { get; }
        IRepository<Ingredient> Ingredient { get; }
        IRepository<IngredientList> IngredientList { get; }
        IRepository<Like> Like { get; }
        IRepository<PreparationGuide> PreparationGuide { get; }
        IRepository<Recipe> Recipe { get; }
        IRepository<RecipeCategory> RecipeCategory { get; }
        IRepository<Step> Step { get; }
        IRepository<Tag> Tag { get; }
        IRepository<TagList> TagList { get; }
        IRepository<User> User { get; }
        IRepository<UserLevel> UserLevel { get; }
        void Commit();

        #region Custom
        IRepository<CustomRecipe> CustomRecipe { get; }
        IRepository<MainUserProfileView> MainUserProfileView { get; }
        IRepository<UserProfileView> UserProfileView { get; }
        IRepository<CustomRecipeByTime> CustomRecipeByTime { get; }
        #endregion
    }
}
