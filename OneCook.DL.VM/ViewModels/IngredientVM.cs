using OneCook.DL.VM.ViewModels;

namespace OneCook.DL.Models
{
    public class IngredientVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IngredientListId { get; set; }
        public string Quantity { get; set; }
        public virtual IngredientListVM IngredientList { get; set; }
        public IngredientVM() { }
        public IngredientVM(Ingredient ingredient)
        {
            Id = ingredient.Id;
            Name = ingredient.Name;
            IngredientListId = ingredient.IngredientListId;
            Quantity = ingredient.Quantity;
            if (ingredient.IngredientList != null)
            {
                IngredientList = new IngredientListVM(ingredient.IngredientList);
            }
        }

    }
}
