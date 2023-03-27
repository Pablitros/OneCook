using OneCook.DL.Models;
using System;

namespace OneCook.DL.VM.ViewModels
{
    public class RecipeVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int TimeCreation { get; set; }
        public string MainImage { get; set; }

        public virtual UserVM User { get; set; }

        public RecipeVM() { }
        public RecipeVM(Recipe recipe)
        {
            Id = recipe.Id;
            UserId = recipe.UserId;
            Name = recipe.Name;
            Description = recipe.Description;
            MainImage = recipe.MainImage;
            CreateDate = recipe.CreateDate;
            TimeCreation = recipe.TimeCreation;
            if (recipe.User != null)
            {
                User = new UserVM(recipe.User);
            }
        }

    }
}
