using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneCook.DL.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(20)]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [MaxLength(400)]
        public string Description { get; set; }
        public string UserUID { get; set; }

        [Required]
        public int UserLevelId { get; set; }

        [Required]
        public string UserImage { get; set; }

        [ForeignKey("UserLevelId")]
        public virtual UserLevel UserLevel { get; set; }

    }
}
