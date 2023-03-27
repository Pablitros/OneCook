using OneCook.DL.Models;
using System;

namespace OneCook.DL.VM.ViewModels
{
    public class CommentVM
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Commentary { get; set; }
        public int UserId { get; set; }
        public virtual UserVM User { get; set; }

        public CommentVM() { }
        public CommentVM(Comment comment)
        {
            Id = comment.Id;
            RecipeId = comment.RecipeId;
            CreateDate = comment.CreateDate;
            Commentary = comment.Commentary;
            UserId = comment.Id;
            if (comment.User != null)
            {
                User = new UserVM(comment.User);
            }
        }

    }
}
