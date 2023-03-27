using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneCook.BL.Services.Interfaces;
using OneCook.DL.Models;

namespace OneCook.Api.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IIngredientServiceBL _ingredientService;

        public IngredientsController(IIngredientServiceBL ingredientService)
        {
            _ingredientService = ingredientService;
        }

        /// <summary>
        /// Gets all the ingredients from the recipe
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpGet("/api/recipes/{recipeId}/Ingredients")]
        public ActionResult<List<IngredientVM>> GetIngredientsFromRecipe(int recipeId)
        {
            var ingredients = _ingredientService.GetIngredientsFromRecipe(recipeId);

            if (ingredients == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(ingredients);
            }
        }
    }
}
