using OneCook.DL.Models;

namespace OneCook.DL.VM.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryVM() { }
        public CategoryVM(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }

    }
}
