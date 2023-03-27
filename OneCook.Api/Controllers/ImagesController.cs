using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneCook.BL.Services.Interfaces;
using OneCook.DL.VM.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OneCook.Api.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IImageServiceBL _imageService;

        public ImagesController(IImageServiceBL imageService)
        {
            _imageService = imageService;
        }


        /// <summary>
        /// Gets all the images from the recipe
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpGet("/api/recipes/{recipeId}/Images")]
        public ActionResult<List<ImageVM>> GetImagesFromRecipe(int recipeId)
        {
            var images = _imageService.GetImagesFromRecipe(recipeId);

            return Ok(images);
        }
    }
}
