using OneCook.BL.Services.Interfaces;
using OneCook.DL.UnitOfWork;
using OneCook.DL.VM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneCook.BL.Services
{
    public class ImageServiceBL : IImageServiceBL
    {
        private readonly IUnitOfWork _uow;

        public ImageServiceBL(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void UploadImage()
        {
            throw new NotImplementedException();
        }

        public void UpdateImage()
        {

        }

        public List<ImageVM> GetImagesFromRecipe(int recipeId)
        {
            var images = _uow.Image.FindAll(x => x.RecipeId == recipeId);

            return images.Select(x => new ImageVM(x)).ToList();
        }
    }
}
