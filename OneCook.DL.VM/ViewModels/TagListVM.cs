using OneCook.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneCook.DL.VM.ViewModels
{
    public class TagListVM
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int TagId { get; set; }
        public TagVM Tag { get; set; }
        public RecipeVM Recipe { get; set; }

        public TagListVM() { }
        public TagListVM(TagList tagList)
        {
            Id = tagList.Id;
            RecipeId = tagList.RecipeId;
            TagId = tagList.TagId;
            if (tagList.Tag != null)
            {
                Tag = new TagVM(tagList.Tag);
            }
            if (tagList.Recipe != null)
            {
                Recipe = new RecipeVM(tagList.Recipe);
            }
        }

    }
}
