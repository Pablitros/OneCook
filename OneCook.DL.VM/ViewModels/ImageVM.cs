using OneCook.DL.Models;
using System;

namespace OneCook.DL.VM.ViewModels
{
    public class ImageVM
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateDate { get; set; }
        public int RecipeId { get; set; }
        public RecipeVM Recipe { get; set; }

        public ImageVM() { }
        public ImageVM(Image image)
        {
            Id = image.Id;
            ImagePath = image.ImagePath;
            CreateDate = image.CreateDate;
            RecipeId = image.RecipeId;
            if (image.Recipe != null)
            {
                Recipe = new RecipeVM(image.Recipe);
            }
        }
    }
}
