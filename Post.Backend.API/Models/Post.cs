using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.API.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string PostContent { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<PostImage> PostImages { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Reaction> PostReactions { get; set; }
        public ICollection<Share> PostShares { get; set; }
        public ICollection<PostVote> PostVotes { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; }
    }
}
