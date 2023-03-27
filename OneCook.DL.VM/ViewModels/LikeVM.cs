using OneCook.DL.VM.ViewModels;
using System;

namespace OneCook.DL.Models
{
    public class LikeVM
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public virtual UserVM User { get; set; }
        public virtual RecipeVM Recipe { get; set; }

        public LikeVM() { }
        public LikeVM(Like like)
        {
            Id = like.Id;
            RecipeId = like.RecipeId;
            CreateDate = like.CreateDate;
            UserId = like.UserId;
            if (like.User != null)
            {
                User = new UserVM(like.User);
            }
            if (like.Recipe != null)
            {
                Recipe = new RecipeVM(like.Recipe);
            }
        }
    }
}
