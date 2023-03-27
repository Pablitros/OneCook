using OneCook.BL.Services.Interfaces;
using OneCook.DL.Models;
using OneCook.DL.UnitOfWork;
using System;
using System.Linq;

namespace OneCook.BL.Services
{
    public class LikeServiceBL : ILikeServiceBL
    {
        private readonly IUnitOfWork _uow;

        public LikeServiceBL(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void LikePost(int recipeId, int userId)
        {
            if (_uow.Like.FindAll(x => x.RecipeId == recipeId && x.UserId == userId).Count() < 1)
            {
                _uow.Like.Insert(new Like() { CreateDate = DateTime.Now, RecipeId = recipeId, UserId = userId });
                _uow.Commit();
            }
        }
        
        public void RemoveLike(int recipeId, int userId)
        {
            var like = _uow.Like.FindAll(x => x.UserId == userId && x.RecipeId == recipeId);
            _uow.Like.Delete(like);
            _uow.Commit();
        }
    }
}
