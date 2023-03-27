using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneCook.DL.Models
{
    [Table("Followers")]
    public class Follower
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int FollowerListId { get; set; }

        [Required]
        public int UserFollowingId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [ForeignKey("UserFollowingId")]
        public virtual User User { get; set; }

        [ForeignKey("FollowerListId")]
        public virtual FollowerList FollowerList { get; set; }
    }
}
