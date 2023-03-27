using OneCook.BL.Services.Interfaces;
using OneCook.DL.Models;
using OneCook.DL.UnitOfWork;
using OneCook.DL.VM.ViewModels;
using OneCook.DL.VM.ViewModels.Custom;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OneCook.BL.Services
{
    public class RecipeServiceBL : IRecipeServiceBL
    {

        private readonly IUnitOfWork _uow;
        public RecipeServiceBL(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void CreateFullRecipe(CreateFullRecipeVM createFullRecipeVM)
        {

            Recipe recipe = new Recipe()
            {
                CreateDate = DateTime.Now,
                Description = createFullRecipeVM.Recipe.Description,
                MainImage = createFullRecipeVM.Recipe.MainImage,
                Name = createFullRecipeVM.Recipe.Name,
                TimeCreation = createFullRecipeVM.Recipe.TimeCreation,
                UserId = createFullRecipeVM.Recipe.UserId
            };

            _uow.Recipe.Insert(recipe);
            _uow.Commit();

            foreach (var r in createFullRecipeVM.RecipeCategory)
            {
                RecipeCategory recipeCategory = new RecipeCategory()
                {
                    RecipeId = recipe.Id,
                    CategoryId = r.CategoryId
                };
                _uow.RecipeCategory.Insert(recipeCategory);
            }
            _uow.Commit();

            IngredientList ingredientList = new IngredientList()
            {
                CreateDate = DateTime.Now,
                RecipeId = recipe.Id
            };

            _uow.IngredientList.Insert(ingredientList);
            _uow.Commit();

            foreach (var i in createFullRecipeVM.Ingredients)
            {
                Ingredient ingredient = new Ingredient()
                {
                    IngredientListId = ingredientList.Id,
                    Name = i.Name,
                    Quantity = i.Quantity
                };
                _uow.Ingredient.Insert(ingredient);
            }
            _uow.Commit();

            foreach (var i in createFullRecipeVM.Images)
            {
                Image image = new Image()
                {
                    CreateDate = DateTime.Now,
                    ImagePath = i.ImagePath,
                    RecipeId = recipe.Id
                };
                _uow.Image.Insert(image);
            }
            _uow.Commit();

            PreparationGuide preparationGuide = new PreparationGuide()
            {
                CreateDate = DateTime.Now,
                RecipeId = recipe.Id
            };

            _uow.PreparationGuide.Insert(preparationGuide);
            _uow.Commit();

            foreach (var s in createFullRecipeVM.Steps)
            {
                Step step = new Step()
                {
                    Content = s.Content,
                    PreparationGuideId = preparationGuide.Id,
                    TimeUsed = s.TimeUsed
                };

                _uow.Step.Insert(step);
            }
            _uow.Commit();

        }

        public List<CustomRecipeVM> GetUsersFollowersRecipes(int currentUserId, int skip)
        {
            int recipesToTake = 10 + 10 * skip;
            string SQL = $"Select top ({recipesToTake}) r.Id as Id, r.Name as Name, r.Description as Description, r.CreateDate as CreateDate, r.MainImage as MainImage, r.TimeCreation as TimeCreation,(Select COUNT(*) from likes where likes.RecipeId = r.id) as RecipeLike, (SELECT COUNT(*) FROM Favorites f where f.RecipeId = r.id) as RecipeFavorites, u.UserImage as UserImage, (Select count(*) from likes l where l.RecipeId = r.Id AND l.UserId = {currentUserId}) as IsLiked, (Select Count(*) from Favorites f where f.UserId = {currentUserId} AND f.RecipeId = r.Id) as IsFavorites from recipes r INNER JOIN Users u ON r.UserId = u.Id where r.userid = (Select f.UserFollowingId from Followers f where f.followerlistId = (Select fl.id from followerLists fl where fl.userId = {currentUserId})) Order by CreateDate desc";

            var recipes = _uow.CustomRecipe.GetBySql(SQL).ToList();

            return recipes.Select(x => new CustomRecipeVM(x)).ToList();
        }

        public List<RecipeVM> GetRecipesByCateogories(List<int> categories)
        {
            string sql = "SELECT * FROM RECIPES r WHERE Id IN (SELECT RecipeId FROM RecipesCategories where CategoryId IN (";

            for (int i = 0; i < categories.Count(); i++)
            {
                if (i == 0)
                {
                    sql += categories[i];
                }
                else
                {
                    sql += $", {categories[i]}";
                }
            }
            sql += "))";

            var query = _uow.Recipe.GetBySql(sql);

            return query.Select(x => new RecipeVM(x)).ToList();
        }

        public List<CustomRecipeVM> GetUsersRecipes(int currentUserId)
        {
            var recipes = _uow.Recipe.FindAll(x => x.UserId == currentUserId);

            //return recipes.Select(x => x.)
            return null;
        }

        public List<CustomRecipeByTimeVM> GetRecipesByTime(string time)
        {
            string sql = "Select r.Id as RecipeId, r.TimeCreation as TimeCreation, r.Name as Name, r.MainImage as RecipeImage, (Select COUNT(*) from likes l where l.RecipeId = r.Id) as LikeQuantity, (Select COUNT(*) from Favorites f where f.RecipeId = r.Id) as RecipeFavorites from Recipes r where r.CreateDate BETWEEN DATEADD({0}) AND GETDATE() order by LikeQuantity DESC";
            switch (time)
            {
                case "day":
                    sql = String.Format(sql, "DAY, -7, GETDATE()");
                    break;

                case "month":
                    sql = String.Format(sql, "MONTH, -1, GETDATE()");
                    break;

                case "year":
                    sql = String.Format(sql, "YEAR, -1, GETDATE()");
                    break;
                default:
                    return null;

            }
            var query = _uow.CustomRecipeByTime.GetBySql(sql);

            return query.Select(x => new CustomRecipeByTimeVM(x)).ToList();
        }

        public RecipeVM GetRecipeById(int id)
        {
            var recipe = _uow.Recipe.FindAll(x => x.Id == id).FirstOrDefault();

            return new RecipeVM(recipe);

        }
    }
}
