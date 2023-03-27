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
    public class CategoryServiceBL : ICategoryServiceBL
    {
        private readonly IUnitOfWork _uow;
        public CategoryServiceBL(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<CategoryVM> GetCategories()
        {
            var categories = _uow.Category.FindAll();
            return categories.Select(x => new CategoryVM(x)).ToList();
        }

        public CategoryVM GetCategoryById(int id)
        {
            var category = _uow.Category.FindAll(x => x.Id == id).FirstOrDefault();
            return new CategoryVM(category);
        }

        public RecipeVM GetRecipesById(int id)
        {
            var recipe = _uow.Recipe.FindAll(x => x.Id == id).FirstOrDefault();
            return new RecipeVM(recipe);
        }

        public List<RecipeVM> GetUsersFollowersRecipes(int currentUserId, int skip)
        {
            int recipesToTake = 10 + 10 * skip;

            var recipes = _uow.Recipe.GetBySql(
                "Select top (" + recipesToTake + ") r.Id, r.Name, r.Description," +
                " r.CreateDate, r.MainImage, r.TimeCreation, (Select COUNT(*) from likes l where l.RecipeId = r.id)" +
                ", (SELECT COUNT(*) FROM Comments c where c.RecipeId = r.id) from recipes r inner join likes l on " +
                "r.id = l.RecipeId INNER JOIN Users u ON r.UserId = u.Id where r.userid = (Select id from Followers" +
                " f where f.followerlistId = (Select fl.id from followerLists fl where fl.userId = " + currentUserId +
                ")) Order by CreateDate desc").ToList();

            return recipes.Select(x => new RecipeVM(x)).ToList();
        }

        public List<RecipeVM> GetRecipes()
        {
            var recipes = _uow.Recipe.FindAll();
            return recipes.Select(x => new RecipeVM(x)).ToList();
        }

        public List<RecipeCategoryVM> GetRecipeCategories(int recipeId)
        {
            var recipeCategory = _uow.RecipeCategory.FindAll(x => x.RecipeId == recipeId);

            return recipeCategory.Select(x => new RecipeCategoryVM(x)).ToList();
        }
    }
}
