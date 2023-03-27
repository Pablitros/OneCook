using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneCook.DL.Models.Custom
{
    [Keyless]
    public class CustomRecipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string MainImage { get; set; }
        public int TimeCreation { get; set; }
        public int RecipeLike { get; set; }
        public int RecipeFavorites { get; set; }
        public string UserImage { get; set; }
        public int IsLiked { get; set; }
        public int IsFavorites { get; set; }
    }
}
