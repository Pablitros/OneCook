using OneCook.DL.VM.ViewModels;
using System;

namespace OneCook.DL.Models
{
    public class PreparationGuideVM
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual RecipeVM Recipe { get; set; }

        public PreparationGuideVM() { }
        public PreparationGuideVM(PreparationGuide preparationGuide)
        {
            Id = preparationGuide.Id;
            RecipeId = preparationGuide.RecipeId;
            CreateDate = preparationGuide.CreateDate;
            if (preparationGuide.Recipe != null)
            {
                Recipe = new RecipeVM(preparationGuide.Recipe);
            }
        }

    }
}