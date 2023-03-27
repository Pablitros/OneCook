using System;
using System.Collections.Generic;
using System.Linq;
using OneCook.DL.Models;
using OneCook.DL.UnitOfWork;

namespace OneCook.BL.Services.Interfaces
{
    public class StepServiceBL : IStepServiceBL
    {
        private readonly IUnitOfWork _uow;

        public StepServiceBL(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<StepVM> GetStepsFromRecipe(int recipeId)
        {
            var preparationGuide = _uow.PreparationGuide.FindAll(x => x.RecipeId == recipeId).FirstOrDefault();

            if (preparationGuide != null)
            {
                var steps = _uow.Step.FindAll(x => x.PreparationGuideId == preparationGuide.Id);

                return steps.Select(x => new StepVM(x)).ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
