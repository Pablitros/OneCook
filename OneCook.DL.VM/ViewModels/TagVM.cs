using OneCook.DL.Models;

namespace OneCook.DL.VM.ViewModels
{
    public class TagVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TagVM() { }
        public TagVM(Tag tag)
        {
            Id = tag.Id;
            Name = tag.Name;
        }

    }
}
