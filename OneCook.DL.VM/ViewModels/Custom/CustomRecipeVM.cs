using System;
using OneCook.DL.Models;
using OneCook.DL.Models.Custom;

namespace OneCook.DL.VM.ViewModels.Custom
{
    public class CustomRecipeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string MainImage { get; set; }
        public int TimeCreation { get; set; }
        public int RecipeLike { get; set; }
        public int RecipeFavorites { get; set; }
        public string UserImage { get; set; }
        public int IsLiked { get; set; }
        public int IsFavorites { get; set; }

        public CustomRecipeVM() { }
        public CustomRecipeVM(CustomRecipe cr)
        {
            Id = cr.Id;
            Name = cr.Name;
            Description = cr.Description;
            CreateDate = cr.CreateDate;
            MainImage = cr.MainImage;
            TimeCreation = cr.TimeCreation;
            RecipeLike = cr.RecipeLike;
            RecipeFavorites = cr.RecipeFavorites;
            UserImage = cr.UserImage;
            IsFavorites = cr.IsFavorites;
            IsLiked = cr.IsLiked;
        }

    }
}
