using System.Collections.Generic;
using OneCook.DL.VM.ViewModels;

namespace OneCook.BL.Services.Interfaces
{
    public interface ICommentServiceBL
    {
        void PostComment(CommentVM commentVM);
        void RemoveComment(int id);
        List<CommentVM> GetCommentsFromRecipe(int recipeId);
    }
}
