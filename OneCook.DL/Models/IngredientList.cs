using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneCook.DL.Models
{
    [Table("IngredientLists")]
    public class IngredientList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int RecipeId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }

    }
}
