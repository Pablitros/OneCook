using System.Collections.Generic;
using OneCook.DL.VM.ViewModels;

namespace OneCook.BL.Services.Interfaces
{
    public interface IImageServiceBL
    {
        public void UploadImage();
        List<ImageVM> GetImagesFromRecipe(int recipeId);
    }
}
