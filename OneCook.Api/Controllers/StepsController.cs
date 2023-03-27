using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneCook.BL.Services.Interfaces;
using OneCook.DL.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OneCook.Api.Controllers
{
    public class StepsController : Controller
    {
        private readonly IStepServiceBL _stepService;

        public StepsController(IStepServiceBL stepService)
        {
            _stepService = stepService;
        }

        /// <summary>
        /// Gets all the steps from a recipe
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpGet("/api/recipes/{recipeId}/steps")]
        public ActionResult<List<StepVM>> GetStepsFromRecipes(int recipeId)
        {
            var steps = _stepService.GetStepsFromRecipe(recipeId);

            if (steps == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(steps);
            }
        }

    }
}
