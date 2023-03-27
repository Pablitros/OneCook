using System.Collections.Generic;
using OneCook.DL.Models;

namespace OneCook.BL.Services.Interfaces
{
    public interface IStepServiceBL
    {
        List<StepVM> GetStepsFromRecipe(int recipeId);
    }
}
