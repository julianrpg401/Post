using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.API.Models
{
    public class UserFollow
    {
        [Key]
        public int UserFollowId { get; set; }

        [Required]
        public int FollowerId { get; set; }

        [Required]
        public int FollowingId { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("FollowerId")]
        public User Follower { get; set; }

        [ForeignKey("FollowingId")]
        public User Following { get; set; }
    }
}
