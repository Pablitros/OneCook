using OneCook.BL.Services.Interfaces;
using OneCook.DL.Models;
using OneCook.DL.UnitOfWork;
using OneCook.DL.VM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneCook.BL.Services
{
    public class CommentServiceBL : ICommentServiceBL
    {
        private readonly IUnitOfWork _uow;
        public CommentServiceBL(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<CommentVM> GetCommentsFromRecipe(int recipeId)
        {
            var comments = _uow.Comment.FindAll(x => x.RecipeId == recipeId, x => x.User);
            return comments.Count() > 0 ? comments.Select(x => new CommentVM(x)).ToList() : null;
        }

        public void PostComment(CommentVM commentVM)
        {
            if (_uow.Recipe.Exists(x => x.Id == commentVM.RecipeId) == true && _uow.User.Exists(x => x.Id == commentVM.UserId) == true)
            {
                Comment comment = new Comment
                {
                    UserId = commentVM.UserId,
                    RecipeId = commentVM.RecipeId,
                    CreateDate = DateTime.Now,
                    Commentary = commentVM.Commentary
                };

                _uow.Comment.Insert(comment);
                _uow.Commit();
            }
        }

        public void RemoveComment(int id)
        {
            _uow.Comment.Delete(id);
            _uow.Commit();
        }
    }
}
