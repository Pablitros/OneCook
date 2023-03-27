using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace OneCook.DL.Models
{
    [Table("Ingredients")]
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public int IngredientListId { get; set; }
        [ForeignKey("IngredientListId")]
        [JsonIgnore]
        public virtual IngredientList IngredientList { get; set; }
    }
}
