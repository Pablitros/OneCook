using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace OneCook.DL.Models
{
    [Table("Steps")]
    public class Step
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PreparationGuideId { get; set; }

        [Required]
        [MaxLength(400)]
        public string Content { get; set; }

        [Required]
        public string TimeUsed { get; set; }

        [ForeignKey("PreparationGuideId")]
        [JsonIgnore]
        public PreparationGuide PreparationGuide { get; set; }

    }
}
