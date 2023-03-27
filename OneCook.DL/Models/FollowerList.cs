using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneCook.DL.Models
{
    [Table("FollowerLists")]
    public class FollowerList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; } // Es el usuario que tiene los seguidores (Como si fuese un perfil de usuario)

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<Follower> Followers { get; set; }
    }
}
