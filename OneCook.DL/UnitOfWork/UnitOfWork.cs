using OneCook.DL.Models;
using OneCook.DL.Models.Context;
using OneCook.DL.Models.Custom;
using OneCook.DL.Repository;

namespace OneCook.DL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DatabaseContext context;
        public UnitOfWork(DatabaseContext context)
        {
            this.context = context;
        }

        public IRepository<Category> category;
        public IRepository<Comment> comment;
        public IRepository<Favorite> favorite;
        public IRepository<Follower> follower;
        public IRepository<FollowerList> followerList;
        public IRepository<Image> image;
        public IRepository<Ingredient> ingredient;
        public IRepository<IngredientList> ingredientList;
        public IRepository<Like> like;
        public IRepository<PreparationGuide> preparationGuide;
        public IRepository<Recipe> recipe;
        public IRepository<RecipeCategory> recipeCateogry;
        public IRepository<Step> step;
        public IRepository<Tag> tag;
        public IRepository<TagList> tagList;
        public IRepository<User> user;
        public IRepository<UserLevel> userLevel;

        public IRepository<CustomRecipe> customRecipe;
        public IRepository<MainUserProfileView> mainUserProfileView { get; set; }
        public IRepository<UserProfileView> userProfileView { get; set; }
        public IRepository<CustomRecipeByTime> customRecipeByTime { get; set; }


        public IRepository<Category> Category => category ?? (category = new Repository<Category>(context));
        public IRepository<Comment> Comment => comment ?? (comment = new Repository<Comment>(context));
        public IRepository<Favorite> Favorite => favorite ?? (favorite = new Repository<Favorite>(context));
        public IRepository<Follower> Follower => follower ?? (follower = new Repository<Follower>(context));
        public IRepository<FollowerList> FollowerList => followerList ?? (followerList = new Repository<FollowerList>(context));
        public IRepository<Image> Image => image ?? (image = new Repository<Image>(context));
        public IRepository<Ingredient> Ingredient => ingredient ?? (ingredient = new Repository<Ingredient>(context));
        public IRepository<IngredientList> IngredientList => ingredientList ?? (ingredientList = new Repository<IngredientList>(context));
        public IRepository<Like> Like => like ?? (like = new Repository<Like>(context));
        public IRepository<PreparationGuide> PreparationGuide => preparationGuide ?? (preparationGuide = new Repository<PreparationGuide>(context));
        public IRepository<Recipe> Recipe => recipe ?? (recipe = new Repository<Recipe>(context));
        public IRepository<RecipeCategory> RecipeCategory => recipeCateogry ?? (recipeCateogry = new Repository<RecipeCategory>(context));
        public IRepository<Step> Step => step ?? (step = new Repository<Step>(context));
        public IRepository<Tag> Tag => tag ?? (tag = new Repository<Tag>(context));
        public IRepository<TagList> TagList => tagList ?? (tagList = new Repository<TagList>(context));
        public IRepository<User> User => user ?? (user = new Repository<User>(context));
        public IRepository<UserLevel> UserLevel => userLevel ?? (userLevel = new Repository<UserLevel>(context));
        public void Commit()
        {
            context.SaveChanges();
        }

        #region Custom
        public IRepository<CustomRecipe> CustomRecipe => customRecipe ?? (customRecipe = new Repository<CustomRecipe>(context));
        public IRepository<MainUserProfileView> MainUserProfileView => mainUserProfileView ?? (mainUserProfileView = new Repository<MainUserProfileView>(context));
        public IRepository<UserProfileView> UserProfileView => userProfileView ?? (userProfileView = new Repository<UserProfileView>(context));
        public IRepository<CustomRecipeByTime> CustomRecipeByTime => customRecipeByTime ?? (customRecipeByTime = new Repository<CustomRecipeByTime>(context));
        #endregion
    }
}
