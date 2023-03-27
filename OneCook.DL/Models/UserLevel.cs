using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneCook.DL.Models
{
    [Table("UserLevels")]
    public class UserLevel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string LevelName { get; set; }
        [Required]
        [Range(0, 99.99)]
        public decimal Price { get; set; }
    }
}
