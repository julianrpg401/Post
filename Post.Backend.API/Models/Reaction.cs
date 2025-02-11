using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.API.Models
{
    public class Reaction
    {
        [Key]
        public int ReactionId { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ReactionTypeId { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ReactionTypeId")]
        public ReactionType ReactionType { get; set; }
    }
}
