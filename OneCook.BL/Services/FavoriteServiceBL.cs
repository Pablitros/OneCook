using OneCook.BL.Services.Interfaces;
using OneCook.DL.Models;
using OneCook.DL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneCook.BL.Services
{
    public class FavoriteServiceBL : IFavoriteServiceBL
    {

        private IUnitOfWork _uow;

        public FavoriteServiceBL(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<FavoriteVM> GetUserFavoriteRecipes(int userId)
        {
            var favorites = _uow.Favorite.FindAll(x => x.UserId == userId, x => x.Recipe);
            return favorites.Select(x => new FavoriteVM(x)).ToList();
        }

        public FavoriteVM GetById(int id)
        {
            var favorite = _uow.Favorite.FindAll(x => x.Id == id).FirstOrDefault();
            return new FavoriteVM(favorite);
        }

        public void AddRecipeToFavorite(int recipeId, int userId)
        {
            if (_uow.Favorite.FindAll(x => x.UserId == userId && x.RecipeId == recipeId).Count() < 1)
            {//Sera un create, ya que no hay recetas que tenga ese usuario añadidas como Favoritas

                Favorite favorite = new Favorite()
                {
                    RecipeId = recipeId,
                    UserId = userId,
                    CreateDate = DateTime.Now
                };

                _uow.Favorite.Insert(favorite);
                _uow.Commit();
            }
        }

        public void RemoveRecipeFromFavories(int recipeId, int userId)
        {
            var fav = _uow.Favorite.FindAll(x => x.RecipeId == recipeId && x.UserId == userId).FirstOrDefault();
            if ( fav != null)
            {
                _uow.Favorite.Delete(fav.Id);
                _uow.Commit();
            }
        }
    }
}
