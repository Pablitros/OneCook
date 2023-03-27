using OneCook.DL.VM.ViewModels;
using System;

namespace OneCook.DL.Models
{
    public class FavoriteVM
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public virtual UserVM User { get; set; }
        public virtual RecipeVM Recipe { get; set; }
        public FavoriteVM() { }
        public FavoriteVM(Favorite favorite)
        {
            Id = favorite.Id;
            RecipeId = favorite.RecipeId;
            CreateDate = favorite.CreateDate;
            UserId = favorite.UserId;
            if (favorite.User != null)
            {
                User = new UserVM(favorite.User);
            }
            if (favorite.Recipe != null)
            {
                Recipe = new RecipeVM(favorite.Recipe);
            }
        }

    }
}
